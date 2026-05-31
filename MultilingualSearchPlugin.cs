using System.Buffers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NuStreamDocs.Plugins;

/// <summary>
/// Splits the Lunr index per locale and applies CJK bigram tokenization for zh-cn and ja.
/// </summary>
internal sealed class MultilingualSearchPlugin : IPlugin, IBuildFinalizePlugin, IPagePostRenderPlugin
{
    private readonly DocsBuildSettings _settings;

    private static ReadOnlySpan<byte> SearchIndexMeta => "nustreamdocs:search-index"u8;
    private static ReadOnlySpan<byte> LunrBindScript => "lunr-bind.js"u8;
    private static ReadOnlySpan<byte> LunrBindMultilingual => "lunr-bind-multilingual.js"u8;

    public MultilingualSearchPlugin(DocsBuildSettings settings)
    {
        _settings = settings;
    }

    public ReadOnlySpan<byte> Name => "multilingual-search"u8;

    public PluginPriority FinalizePriority => new(PluginBand.Latest, 100);

    public PluginPriority PostRenderPriority => new(PluginBand.Latest, 50);

    public ValueTask FinalizeAsync(BuildFinalizeContext context, CancellationToken cancellationToken)
    {
        var outputRoot = context.OutputRoot.ToString();
        var sourceIndex = Path.Combine(outputRoot, "search", "search_index.json");
        if (!File.Exists(sourceIndex))
        {
            return default;
        }

        SplitSearchIndex(sourceIndex, outputRoot);
        CopyMultilingualBindScript(outputRoot);
        return default;
    }

    public bool NeedsRewrite(ReadOnlySpan<byte> html) =>
        html.IndexOf(SearchIndexMeta) >= 0 || html.IndexOf(LunrBindScript) >= 0;

    public void PostRender(in PagePostRenderContext context)
    {
        var relative = context.RelativePath.Value.Replace('\\', '/');
        var locale = DocsLocale.FromRelativeMarkdown(relative);
        var segment = DocsLocale.SearchIndexSegment(locale);
        var indexPath = $"/search/{segment}/search_index.json";

        var html = Encoding.UTF8.GetString(context.Html);
        html = html.Replace(
            "lunr-bind.js",
            "lunr-bind-multilingual.js",
            StringComparison.Ordinal);
        html = ReplaceSearchIndexMeta(html, indexPath);
        WriteUtf8(context.Output, html);
    }

    private void SplitSearchIndex(string sourceIndex, string outputRoot)
    {
        var root = JsonNode.Parse(File.ReadAllText(sourceIndex)) as JsonObject;
        if (root?["docs"] is not JsonArray docs)
        {
            return;
        }

        var config = root["config"]?.DeepClone() as JsonObject ?? new JsonObject();
        WriteLocaleIndex(outputRoot, "en", config, FilterDocs(docs, DocsLocale.Kind.English, applyCjk: false));
        WriteLocaleIndex(outputRoot, "zh-cn", config, FilterDocs(docs, DocsLocale.Kind.ZhCn, applyCjk: true));
        WriteLocaleIndex(outputRoot, "ja", config, FilterDocs(docs, DocsLocale.Kind.Ja, applyCjk: true));
    }

    private static JsonArray FilterDocs(JsonArray docs, DocsLocale.Kind locale, bool applyCjk)
    {
        var filtered = new JsonArray();
        foreach (var node in docs)
        {
            if (node is not JsonObject doc)
            {
                continue;
            }

            var location = doc["location"]?.GetValue<string>();
            if (location is null || !BelongsToLocale(location, locale))
            {
                continue;
            }

            var clone = doc.DeepClone() as JsonObject ?? new JsonObject();
            if (applyCjk)
            {
                if (clone["text"] is JsonValue textNode && textNode.TryGetValue<string>(out var text))
                {
                    clone["text"] = CjkBigramTokenizer.Apply(text);
                }

                if (clone["title"] is JsonValue titleNode && titleNode.TryGetValue<string>(out var title))
                {
                    clone["title"] = CjkBigramTokenizer.Apply(title);
                }
            }

            filtered.Add(clone);
        }

        return filtered;
    }

    private static bool BelongsToLocale(string location, DocsLocale.Kind locale) =>
        locale switch
        {
            DocsLocale.Kind.ZhCn => location.StartsWith("/zh-cn/", StringComparison.OrdinalIgnoreCase)
                                    || location.Equals("/zh-cn/", StringComparison.OrdinalIgnoreCase),
            DocsLocale.Kind.Ja => location.StartsWith("/ja/", StringComparison.OrdinalIgnoreCase)
                                  || location.Equals("/ja/", StringComparison.OrdinalIgnoreCase),
            _ => !location.StartsWith("/zh-cn/", StringComparison.OrdinalIgnoreCase)
                 && !location.StartsWith("/ja/", StringComparison.OrdinalIgnoreCase),
        };

    private static void WriteLocaleIndex(string outputRoot, string segment, JsonObject config, JsonArray docs)
    {
        var dir = Path.Combine(outputRoot, "search", segment);
        Directory.CreateDirectory(dir);
        var payload = new JsonObject
        {
            ["config"] = config.DeepClone(),
            ["docs"] = docs,
        };
        var options = new JsonSerializerOptions { WriteIndented = false };
        File.WriteAllText(Path.Combine(dir, "search_index.json"), payload.ToJsonString(options));
    }

    private void CopyMultilingualBindScript(string outputRoot)
    {
        var source = ResolveAssetPath("assets", "javascripts", "lunr-bind-multilingual.js");
        if (!File.Exists(source))
        {
            Console.WriteLine($"Warning: multilingual Lunr bind script not found at '{source}'.");
            return;
        }

        var destDir = Path.Combine(outputRoot, "assets", "javascripts");
        Directory.CreateDirectory(destDir);
        File.Copy(source, Path.Combine(destDir, "lunr-bind-multilingual.js"), overwrite: true);
    }

    private string CombineBasePath(string path)
    {
        if (string.IsNullOrEmpty(_settings.BasePath))
        {
            return path;
        }

        return _settings.BasePath.TrimEnd('/') + path;
    }

    private string ReplaceSearchIndexMeta(string html, string indexPath)
    {
        const string marker = "name=\"nustreamdocs:search-index\" content=\"";
        var start = html.IndexOf(marker, StringComparison.Ordinal);
        if (start < 0)
        {
            return html;
        }

        start += marker.Length;
        var end = html.IndexOf('"', start);
        if (end < 0)
        {
            return html;
        }

        return html[..start] + indexPath + html[end..];
    }

    private static string ResolveAssetPath(params string[] parts)
    {
        foreach (var root in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
        {
            var candidate = Path.GetFullPath(Path.Combine(root, Path.Combine(parts)));
            if (File.Exists(candidate))
            {
                return candidate;
            }
        }

        return Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, Path.Combine(parts)));
    }

    private static void WriteUtf8(System.Buffers.IBufferWriter<byte> writer, string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var dst = writer.GetSpan(bytes.Length);
        bytes.CopyTo(dst);
        writer.Advance(bytes.Length);
    }
}
