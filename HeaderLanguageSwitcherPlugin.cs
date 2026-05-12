using System.Buffers;
using System.Text;
using NuStreamDocs.Common;
using NuStreamDocs.Plugins;

/// <summary>
/// Injects EN / 简体 / 日本語 links in the header immediately after the palette (theme) toggle.
/// </summary>
internal sealed class HeaderLanguageSwitcherPlugin : IPlugin, IPagePostRenderPlugin
{
    private static ReadOnlySpan<byte> PaletteToggleNeedle => "data-md-component=\"palette-toggle\""u8;
    private static ReadOnlySpan<byte> ButtonClose => "</button>"u8;
    private static ReadOnlySpan<byte> LangMarker => "md-header__lang"u8;
    private static ReadOnlySpan<byte> HtmlOpen => "<html"u8;

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

        return html.IndexOf(PaletteToggleNeedle) >= 0;
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
        if (i < 0)
        {
            return false;
        }

        var slice = html[i..];
        var close = slice.IndexOf(ButtonClose);
        if (close < 0)
        {
            return false;
        }

        insertAt = i + close + ButtonClose.Length;
        return true;
    }

    private static byte[] BuildFragmentBytes(string relativeMarkdown)
    {
        var contentKey = StripLocalePrefix(relativeMarkdown);
        var en = ToServedDirectoryPath(contentKey);
        var zh = ToServedDirectoryPath("zh-cn/" + contentKey);
        var ja = ToServedDirectoryPath("ja/" + contentKey);

        var enActive = IsLocale(relativeMarkdown, LocaleKind.English);
        var zhActive = IsLocale(relativeMarkdown, LocaleKind.ZhCn);
        var jaActive = IsLocale(relativeMarkdown, LocaleKind.Ja);

        var enAttr = enActive
            ? " aria-current=\"page\" class=\"md-header__lang-link md-header__lang-link--active\""
            : " class=\"md-header__lang-link\"";
        var zhAttr = zhActive
            ? " aria-current=\"page\" class=\"md-header__lang-link md-header__lang-link--active\""
            : " class=\"md-header__lang-link\"";
        var jaAttr = jaActive
            ? " aria-current=\"page\" class=\"md-header__lang-link md-header__lang-link--active\""
            : " class=\"md-header__lang-link\"";

        var s =
            $"<div class=\"md-header__lang\" role=\"group\" aria-label=\"Language\"><a{enAttr} href=\"{en}\" lang=\"en\">EN</a><a{zhAttr} href=\"{zh}\" lang=\"zh-Hans\">简体</a><a{jaAttr} href=\"{ja}\" lang=\"ja\">日本語</a></div>";
        return Encoding.UTF8.GetBytes(s);
    }

    private static string StripLocalePrefix(string relativeMarkdown)
    {
        if (relativeMarkdown.StartsWith("zh-cn/", StringComparison.OrdinalIgnoreCase))
        {
            return relativeMarkdown[6..];
        }

        if (relativeMarkdown.StartsWith("ja/", StringComparison.OrdinalIgnoreCase))
        {
            return relativeMarkdown[3..];
        }

        return relativeMarkdown;
    }

    private enum LocaleKind
    {
        English,
        ZhCn,
        Ja,
    }

    private static bool IsLocale(string relativeMarkdown, LocaleKind kind) =>
        kind switch
        {
            LocaleKind.English => !relativeMarkdown.StartsWith("zh-cn/", StringComparison.OrdinalIgnoreCase)
                                 && !relativeMarkdown.StartsWith("ja/", StringComparison.OrdinalIgnoreCase),
            LocaleKind.ZhCn => relativeMarkdown.StartsWith("zh-cn/", StringComparison.OrdinalIgnoreCase),
            LocaleKind.Ja => relativeMarkdown.StartsWith("ja/", StringComparison.OrdinalIgnoreCase),
            _ => false,
        };

    private static string ToServedDirectoryPath(string markdownRelative)
    {
        var p = markdownRelative.Replace('\\', '/');
        if (!p.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
        {
            p += ".md";
        }

        var stem = p[..^3];
        var lastSlash = stem.LastIndexOf('/');
        var fileName = lastSlash >= 0 ? stem[(lastSlash + 1)..] : stem;
        if (fileName.Equals("index", StringComparison.OrdinalIgnoreCase))
        {
            var dir = lastSlash >= 0 ? stem[..lastSlash] : string.Empty;
            return string.IsNullOrEmpty(dir) ? "/" : "/" + dir + "/";
        }

        return "/" + stem + "/";
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
