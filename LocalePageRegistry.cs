using NuStreamDocs.Plugins;

/// <summary>Tracks which markdown pages exist per locale (build-time scan of the input tree).</summary>
internal sealed class LocalePageRegistry : IPlugin, IBuildConfigurePlugin
{
    private readonly HashSet<string> _relativePaths = new(StringComparer.OrdinalIgnoreCase);

    public ReadOnlySpan<byte> Name => "locale-page-registry"u8;

    public PluginPriority ConfigurePriority => new(PluginBand.Early, 0);

    public ValueTask ConfigureAsync(BuildConfigureContext context, CancellationToken cancellationToken)
    {
        _relativePaths.Clear();
        var inputRoot = context.InputRoot.ToString();
        if (!Directory.Exists(inputRoot))
        {
            return default;
        }

        foreach (var file in Directory.EnumerateFiles(inputRoot, "*.md", SearchOption.AllDirectories))
        {
            var relative = Path.GetRelativePath(inputRoot, file).Replace('\\', '/');
            _relativePaths.Add(relative);
        }

        return default;
    }

    public bool Exists(DocsLocale.Kind locale, string contentKey)
    {
        var markdown = DocsLocale.MarkdownPathFor(locale, contentKey);
        return _relativePaths.Contains(markdown);
    }

    public IEnumerable<DocsLocale.Kind> ExistingLocales(string contentKey)
    {
        if (Exists(DocsLocale.Kind.English, contentKey))
        {
            yield return DocsLocale.Kind.English;
        }

        if (Exists(DocsLocale.Kind.ZhCn, contentKey))
        {
            yield return DocsLocale.Kind.ZhCn;
        }

        if (Exists(DocsLocale.Kind.Ja, contentKey))
        {
            yield return DocsLocale.Kind.Ja;
        }
    }
}
