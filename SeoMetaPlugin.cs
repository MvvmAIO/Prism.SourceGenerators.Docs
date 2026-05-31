using System.Buffers;
using System.Text;
using NuStreamDocs.Plugins;

/// <summary>Injects locale-aware html lang, canonical, and hreflang link elements.</summary>
internal sealed class SeoMetaPlugin : IPlugin, IPagePostRenderPlugin
{
    private readonly DocsBuildSettings _settings;
    private readonly LocalePageRegistry _registry;

    private static ReadOnlySpan<byte> HtmlOpen => "<html"u8;
    private static ReadOnlySpan<byte> HeadOpen => "<head>"u8;
    private static ReadOnlySpan<byte> SeoMarker => "docs-seo-meta"u8;

    public SeoMetaPlugin(DocsBuildSettings settings, LocalePageRegistry registry)
    {
        _settings = settings;
        _registry = registry;
    }

    public ReadOnlySpan<byte> Name => "seo-meta"u8;

    public PluginPriority PostRenderPriority => new(PluginBand.Latest, 10);

    public bool NeedsRewrite(ReadOnlySpan<byte> html) =>
        html.IndexOf(HtmlOpen) >= 0 && html.IndexOf(SeoMarker) < 0;

    public void PostRender(in PagePostRenderContext context)
    {
        var relative = context.RelativePath.Value.Replace('\\', '/');
        var locale = DocsLocale.FromRelativeMarkdown(relative);
        var contentKey = DocsLocale.StripPrefix(relative);
        var htmlLang = DocsLocale.HtmlLang(locale);
        var servedPath = DocsLocale.ToServedDirectoryPath(locale, contentKey);
        var canonical = _settings.SiteUrl.TrimEnd('/') + servedPath;

        var html = Encoding.UTF8.GetString(context.Html);
        html = ReplaceHtmlLang(html, htmlLang);
        html = InjectSeoLinks(html, locale, contentKey, canonical);
        WriteUtf8(context.Output, html);
    }

    private string ReplaceHtmlLang(string html, string lang)
    {
        const string prefix = "<html lang=\"";
        var start = html.IndexOf(prefix, StringComparison.Ordinal);
        if (start < 0)
        {
            return html;
        }

        start += prefix.Length;
        var end = html.IndexOf('"', start);
        if (end < 0)
        {
            return html;
        }

        return html[..start] + lang + html[end..];
    }

    private string InjectSeoLinks(string html, DocsLocale.Kind locale, string contentKey, string canonical)
    {
        var headIdx = html.IndexOf("<head>", StringComparison.Ordinal);
        if (headIdx < 0)
        {
            return html;
        }

        var insertAt = headIdx + "<head>".Length;
        var sb = new StringBuilder();
        sb.Append("<meta name=\"docs-seo-meta\" content=\"1\">");
        sb.Append("<link rel=\"canonical\" href=\"").Append(canonical).Append("\">");

        foreach (var existing in _registry.ExistingLocales(contentKey))
        {
            var path = DocsLocale.ToServedDirectoryPath(existing, contentKey);
            var href = _settings.SiteUrl.TrimEnd('/') + path;
            sb.Append("<link rel=\"alternate\" hreflang=\"")
                .Append(DocsLocale.HrefLang(existing))
                .Append("\" href=\"")
                .Append(href)
                .Append("\">");
        }

        if (_registry.Exists(DocsLocale.Kind.English, contentKey))
        {
            var enPath = DocsLocale.ToServedDirectoryPath(DocsLocale.Kind.English, contentKey);
            var enHref = _settings.SiteUrl.TrimEnd('/') + enPath;
            sb.Append("<link rel=\"alternate\" hreflang=\"x-default\" href=\"")
                .Append(enHref)
                .Append("\">");
        }

        return html[..insertAt] + sb + html[insertAt..];
    }

    private static void WriteUtf8(IBufferWriter<byte> writer, string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);
        var dst = writer.GetSpan(bytes.Length);
        bytes.CopyTo(dst);
        writer.Advance(bytes.Length);
    }
}
