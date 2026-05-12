using NuStreamDocs.Building;
using NuStreamDocs.Config.MkDocs;
using NuStreamDocs.Highlight;
using NuStreamDocs.MarkdownExtensions;
using NuStreamDocs.Nav;
using NuStreamDocs.Search.Lunr;
using NuStreamDocs.Sitemap;
using NuStreamDocs.Theme.Material3;
using NuStreamDocs.Toc;

static string ResolveContentPath(string relative)
{
    var fromBase = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, relative));
    if (File.Exists(fromBase) || Directory.Exists(fromBase))
        return fromBase;

    var fromCwd = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), relative));
    if (File.Exists(fromCwd) || Directory.Exists(fromCwd))
        return fromCwd;

    return fromBase;
}

var outDir = Path.GetFullPath(args.Length > 0 ? args[0] : "site");
var siteUrl = Environment.GetEnvironmentVariable("DOCS_SITE_URL")?.Trim();
if (string.IsNullOrEmpty(siteUrl))
{
    siteUrl = "https://mvvmaio.github.io/Prism.SourceGenerators.Docs/";
}

var docsDir = ResolveContentPath("docs");
var mkdocsFile = ResolveContentPath("mkdocs.yml");

var pages = await new DocBuilder()
    .WithInput(docsDir)
    .WithOutput(outDir)
    .WithSiteUrl(siteUrl)
    .UseDirectoryUrls()
    .UseMkDocsConfig(mkdocsFile)
    .UseMaterial3Theme()
    .UseNav(opts => opts with { Prune = true })
    .UseToc()
    .UseHighlight()
    .UseLunrSearch()
    .UseCommonMarkdownExtensions()
    .UseSitemap()
    .UseNotFoundPage()
    .BuildAsync();

Console.WriteLine($"Built {pages} page(s) into '{outDir}'.");
