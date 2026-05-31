/// <summary>Build-time settings shared across custom NuStreamDocs plugins.</summary>
internal sealed class DocsBuildSettings
{
    public required string SiteUrl { get; init; }

    /// <summary>
    /// Path prefix for GitHub project Pages (e.g. <c>/Prism.SourceGenerators.Docs/</c>).
    /// Empty for local root-absolute output.
    /// </summary>
    public required string BasePath { get; init; }

    public static DocsBuildSettings Resolve()
    {
        var siteUrl = Environment.GetEnvironmentVariable("DOCS_SITE_URL")?.Trim();
        if (string.IsNullOrEmpty(siteUrl))
        {
            siteUrl = "https://mvvmaio.github.io/Prism.SourceGenerators.Docs/";
        }

        var basePath = Environment.GetEnvironmentVariable("DOCS_BASE_PATH")?.Trim();
        if (basePath is null)
        {
            basePath = string.Empty;
        }
        else if (basePath.Length > 0)
        {
            if (!basePath.StartsWith('/'))
            {
                basePath = "/" + basePath;
            }

            if (!basePath.EndsWith('/'))
            {
                basePath += "/";
            }
        }

        return new DocsBuildSettings
        {
            SiteUrl = siteUrl.TrimEnd('/') + "/",
            BasePath = basePath,
        };
    }
}
