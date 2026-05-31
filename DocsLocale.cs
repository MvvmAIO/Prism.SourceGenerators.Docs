/// <summary>Locale helpers for tri-lingual docs (EN / zh-cn / ja).</summary>
public static class DocsLocale
{
    public enum Kind
    {
        English,
        ZhCn,
        Ja,
    }

    internal static Kind FromRelativeMarkdown(string relativeMarkdown)
    {
        var p = relativeMarkdown.Replace('\\', '/');
        if (p.StartsWith("zh-cn/", StringComparison.OrdinalIgnoreCase))
        {
            return Kind.ZhCn;
        }

        if (p.StartsWith("ja/", StringComparison.OrdinalIgnoreCase))
        {
            return Kind.Ja;
        }

        return Kind.English;
    }

    public static string StripPrefix(string relativeMarkdown)
    {
        var p = relativeMarkdown.Replace('\\', '/');
        if (p.StartsWith("zh-cn/", StringComparison.OrdinalIgnoreCase))
        {
            return p[6..];
        }

        if (p.StartsWith("ja/", StringComparison.OrdinalIgnoreCase))
        {
            return p[3..];
        }

        return p;
    }

    internal static string HtmlLang(Kind kind) =>
        kind switch
        {
            Kind.ZhCn => "zh-Hans",
            Kind.Ja => "ja",
            _ => "en",
        };

    internal static string HrefLang(Kind kind) =>
        kind switch
        {
            Kind.ZhCn => "zh-Hans",
            Kind.Ja => "ja",
            _ => "en",
        };

    internal static string SearchIndexSegment(Kind kind) =>
        kind switch
        {
            Kind.ZhCn => "zh-cn",
            Kind.Ja => "ja",
            _ => "en",
        };

    internal static string MarkdownPathFor(Kind kind, string contentKey)
    {
        var key = contentKey.Replace('\\', '/');
        return kind switch
        {
            Kind.ZhCn => "zh-cn/" + key,
            Kind.Ja => "ja/" + key,
            _ => key,
        };
    }

    public static string ToServedDirectoryPath(string markdownRelative)
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

    public static string ToServedDirectoryPath(Kind locale, string contentKey)
    {
        var path = ToServedDirectoryPath(contentKey);
        return locale switch
        {
            Kind.ZhCn => path == "/" ? "/zh-cn/" : "/zh-cn" + path,
            Kind.Ja => path == "/" ? "/ja/" : "/ja" + path,
            _ => path,
        };
    }
}
