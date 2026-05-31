using System.Buffers;
using System.Text;
using NuStreamDocs.Common;
using NuStreamDocs.Plugins;

/// <summary>
/// Injects EN / 简体 / 日本語 links in the header immediately after the palette (theme) toggle.
/// </summary>
internal sealed class HeaderLanguageSwitcherPlugin : IPlugin, IPagePostRenderPlugin
{
    private readonly LocalePageRegistry _registry;

    private static ReadOnlySpan<byte> PaletteToggleNeedle => "data-md-component=\"palette-toggle\""u8;
    private static ReadOnlySpan<byte> HeaderInnerNeedle => "class=\"md-header__inner"u8;
    private static ReadOnlySpan<byte> ButtonClose => "</button>"u8;
    private static ReadOnlySpan<byte> LangMarker => "md-header__lang"u8;
    private static ReadOnlySpan<byte> HtmlOpen => "<html"u8;

    public HeaderLanguageSwitcherPlugin(LocalePageRegistry registry)
    {
        _registry = registry;
    }

    public ReadOnlySpan<byte> Name => "header-language-switcher"u8;

    public PluginPriority PostRenderPriority => new(PluginBand.Latest, 100);

    public bool NeedsRewrite(ReadOnlySpan<byte> html)
    {
        if (html.IndexOf(HtmlOpen) < 0)
        {
            return false;
        }

        if (html.IndexOf(LangMarker) >= 0)
        {
            return false;
        }

        return html.IndexOf(PaletteToggleNeedle) >= 0 || html.IndexOf(HeaderInnerNeedle) >= 0;
    }

    public void PostRender(in PagePostRenderContext context)
    {
        var html = context.Html;
        if (!TryFindInsertPosition(html, out var insertAt))
        {
            WriteAll(context.Output, html);
            return;
        }

        var relative = context.RelativePath.Value.Replace('\\', '/');
        var fragment = BuildFragmentBytes(relative);

        WriteAll(context.Output, html[..insertAt]);
        WriteAll(context.Output, fragment);
        WriteAll(context.Output, html[insertAt..]);
    }

    private static void WriteAll(IBufferWriter<byte> writer, byte[] bytes) =>
        WriteAll(writer, bytes.AsSpan());

    private static bool TryFindInsertPosition(ReadOnlySpan<byte> html, out int insertAt)
    {
        insertAt = 0;
        var i = html.IndexOf(PaletteToggleNeedle);
        if (i >= 0)
        {
            var slice = html[i..];
            var close = slice.IndexOf(ButtonClose);
            if (close >= 0)
            {
                insertAt = i + close + ButtonClose.Length;
                return true;
            }
        }

        var inner = html.IndexOf(HeaderInnerNeedle);
        if (inner < 0)
        {
            return false;
        }

        var headerClose = html.IndexOf("</nav>"u8);
        if (headerClose < 0 || headerClose <= inner)
        {
            return false;
        }

        insertAt = headerClose + "</nav>".Length;
        return true;
    }

    private byte[] BuildFragmentBytes(string relativeMarkdown)
    {
        var contentKey = DocsLocale.StripPrefix(relativeMarkdown);
        var current = DocsLocale.FromRelativeMarkdown(relativeMarkdown);

        var sb = new StringBuilder();
        sb.Append("<div class=\"md-header__lang\" role=\"group\" aria-label=\"Language\">");

        AppendLink(sb, DocsLocale.Kind.English, contentKey, current, "EN", "en");
        AppendLink(sb, DocsLocale.Kind.ZhCn, contentKey, current, "简体", "zh-Hans");
        AppendLink(sb, DocsLocale.Kind.Ja, contentKey, current, "日本語", "ja");

        sb.Append("</div>");
        return Encoding.UTF8.GetBytes(sb.ToString());
    }

    private void AppendLink(
        StringBuilder sb,
        DocsLocale.Kind locale,
        string contentKey,
        DocsLocale.Kind current,
        string label,
        string lang)
    {
        if (!_registry.Exists(locale, contentKey))
        {
            return;
        }

        var href = DocsLocale.ToServedDirectoryPath(locale, contentKey);
        var active = locale == current;
        if (active)
        {
            sb.Append("<a aria-current=\"page\" class=\"md-header__lang-link md-header__lang-link--active\" href=\"")
                .Append(href)
                .Append("\" lang=\"")
                .Append(lang)
                .Append("\">")
                .Append(label)
                .Append("</a>");
        }
        else
        {
            sb.Append("<a class=\"md-header__lang-link\" href=\"")
                .Append(href)
                .Append("\" lang=\"")
                .Append(lang)
                .Append("\">")
                .Append(label)
                .Append("</a>");
        }
    }

    private static void WriteAll(IBufferWriter<byte> writer, ReadOnlySpan<byte> span)
    {
        if (span.IsEmpty)
        {
            return;
        }

        var dst = writer.GetSpan(span.Length);
        span.CopyTo(dst);
        writer.Advance(span.Length);
    }
}
