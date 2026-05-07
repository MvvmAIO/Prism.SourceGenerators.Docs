using System.Collections.Concurrent;
using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Prism.SourceGenerators.Docs.Services;

/// <summary>
/// Loads nested locale JSON from <c>wwwroot/locales/{culture}.json</c> and exposes flat keys (<c>nav.home</c>).
/// </summary>
public sealed class LocalizationService
{
    public static readonly string[] SupportedCultures = ["en", "zh-CN", "ja"];

    private readonly HttpClient _http;
    private readonly string _baseUri;
    private readonly ConcurrentDictionary<string, Dictionary<string, string>> _cache = new(StringComparer.OrdinalIgnoreCase);
    private string _culture = "en";
    private bool _initialCultureApplied;

    public LocalizationService(HttpClient http, IWebAssemblyHostEnvironment host)
    {
        _http = http;
        _baseUri = host.BaseAddress.ToString().TrimEnd('/') + '/';
    }

    public event Action? CultureChanged;

    public string Culture => _culture;

    public string T(string key)
    {
        if (_cache.TryGetValue(_culture, out var map) && map.TryGetValue(key, out var value))
            return value;
        if (_culture != "en" && _cache.TryGetValue("en", out var en) && en.TryGetValue(key, out var fallback))
            return fallback;
        return key;
    }

    public async Task SetCultureAsync(string culture, CancellationToken cancellationToken = default)
    {
        culture = ResolveSupportedCulture(culture);
        await EnsureCultureLoadedAsync(culture, cancellationToken).ConfigureAwait(false);
        if (culture != "en")
            await EnsureCultureLoadedAsync("en", cancellationToken).ConfigureAwait(false);
        _culture = culture;
        CultureChanged?.Invoke();
    }

    /// <summary>
    /// Maps any culture name to <see cref="SupportedCultures"/>; unknown or invalid values become <c>en</c>.
    /// </summary>
    public static string ResolveSupportedCulture(string? cultureName)
    {
        if (string.IsNullOrWhiteSpace(cultureName))
            return "en";

        var name = cultureName.Trim().Replace('_', '-');

        foreach (var s in SupportedCultures)
        {
            if (name.Equals(s, StringComparison.OrdinalIgnoreCase))
                return s;
        }

        if (name.StartsWith("en-", StringComparison.OrdinalIgnoreCase))
            return "en";

        if (name.StartsWith("zh", StringComparison.OrdinalIgnoreCase))
            return "zh-CN";

        if (name.StartsWith("ja", StringComparison.OrdinalIgnoreCase))
            return "ja";

        try
        {
            var ci = CultureInfo.GetCultureInfo(name);
            for (var c = ci; c != CultureInfo.InvariantCulture && !string.IsNullOrEmpty(c.Name); c = c.Parent)
            {
                if (c.TwoLetterISOLanguageName.Equals("ja", StringComparison.OrdinalIgnoreCase))
                    return "ja";
                if (c.TwoLetterISOLanguageName.Equals("zh", StringComparison.OrdinalIgnoreCase))
                    return "zh-CN";
                if (c.TwoLetterISOLanguageName.Equals("en", StringComparison.OrdinalIgnoreCase))
                    return "en";
            }
        }
        catch (CultureNotFoundException)
        {
            // fall through to en
        }

        return "en";
    }

    private static bool HasConcreteCulture(CultureInfo culture) =>
        !ReferenceEquals(culture, CultureInfo.InvariantCulture) && !string.IsNullOrEmpty(culture.Name);

    /// <summary>
    /// Picks UI culture: <see cref="CultureInfo.CurrentUICulture"/>, then <see cref="CultureInfo.CurrentCulture"/>,
    /// then optional <paramref name="navigatorLanguage"/> (e.g. from JS <c>navigator.language</c>), else English.
    /// </summary>
    public async Task ApplyInitialCultureAsync(string? navigatorLanguage = null, CancellationToken cancellationToken = default)
    {
        if (_initialCultureApplied)
            return;

        string chosen;

        if (HasConcreteCulture(CultureInfo.CurrentUICulture))
        {
            chosen = ResolveSupportedCulture(CultureInfo.CurrentUICulture.Name);
        }
        else if (HasConcreteCulture(CultureInfo.CurrentCulture))
        {
            chosen = ResolveSupportedCulture(CultureInfo.CurrentCulture.Name);
        }
        else if (!string.IsNullOrWhiteSpace(navigatorLanguage))
        {
            chosen = ResolveSupportedCulture(navigatorLanguage);
        }
        else
        {
            chosen = "en";
        }

        await SetCultureAsync(chosen, cancellationToken).ConfigureAwait(false);
        _initialCultureApplied = true;
    }

    private async Task EnsureCultureLoadedAsync(string culture, CancellationToken cancellationToken)
    {
        if (_cache.ContainsKey(culture))
            return;

        var flat = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            var path = $"{_baseUri}locales/{culture}.json";
            await using var stream = await _http.GetStreamAsync(path, cancellationToken).ConfigureAwait(false);
            using var doc = await JsonDocument.ParseAsync(stream, cancellationToken: cancellationToken).ConfigureAwait(false);
            Flatten(doc.RootElement, "", flat);
        }
        catch
        {
            // Missing or invalid locale file — leave map empty; T() may fall back to en.
        }

        _cache[culture] = flat;
    }

    private static void Flatten(JsonElement element, string prefix, Dictionary<string, string> target)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var prop in element.EnumerateObject())
                {
                    var next = string.IsNullOrEmpty(prefix) ? prop.Name : $"{prefix}.{prop.Name}";
                    Flatten(prop.Value, next, target);
                }
                break;
            case JsonValueKind.String:
                target[prefix] = element.GetString() ?? "";
                break;
            case JsonValueKind.Number:
                target[prefix] = element.GetRawText();
                break;
            case JsonValueKind.True:
            case JsonValueKind.False:
                target[prefix] = element.GetBoolean().ToString(CultureInfo.InvariantCulture);
                break;
        }
    }
}
