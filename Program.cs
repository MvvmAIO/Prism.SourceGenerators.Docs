using NuStreamDocs.Building;
using NuStreamDocs.Config.MkDocs;
using NuStreamDocs.Highlight;
using NuStreamDocs.MarkdownExtensions;
using NuStreamDocs.Nav;
using NuStreamDocs.Search.Lunr;
using NuStreamDocs.Sitemap;
using NuStreamDocs.Theme.Material3;
using NuStreamDocs.Toc;

#if DEBUG
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
#endif

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
var buildSettings = DocsBuildSettings.Resolve();

var docsDir = ResolveContentPath("docs");
var mkdocsFile = ResolveContentPath("mkdocs.yml");
var responsiveCss = ResolveContentPath(Path.Combine("styles", "responsive.css"));

var localeRegistry = new LocalePageRegistry();

var configured = new DocBuilder()
    .WithInput(docsDir)
    .WithOutput(outDir)
    .WithSiteUrl(buildSettings.SiteUrl)
    .UseDirectoryUrls()
    .UseMkDocsConfig(mkdocsFile)
    .UseMaterial3Theme()
    .UsePlugin(localeRegistry)
    .UsePlugin(new SeoMetaPlugin(buildSettings, localeRegistry))
    .UsePlugin(new HeaderLanguageSwitcherPlugin(localeRegistry))
    .UsePlugin(new SiteBasePathPlugin(buildSettings))
    .UsePlugin(new MultilingualSearchPlugin(buildSettings));

if (File.Exists(responsiveCss))
{
    configured = configured.AddExtraCss(responsiveCss);
}
else
{
    Console.WriteLine($"Warning: responsive stylesheet not found at '{responsiveCss}'.");
}

var pages = await configured
    .UseNav(opts => opts with { Prune = true })
    .UseToc()
    .UseHighlight()
    .UseLunrSearch()
    .UseCommonMarkdownExtensions()
    .UseSitemap()
    .UseNotFoundPage()
    .BuildAsync();

Console.WriteLine($"Built {pages} page(s) into '{outDir}'.");

#if DEBUG
if (args.Length > 1 && args[1] == "--serve")
{
    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();
    var fileProvider = new PhysicalFileProvider(outDir);

    app.UseDefaultFiles(new DefaultFilesOptions
    {
        FileProvider = fileProvider,
        RequestPath = "",
    });

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = fileProvider,
        RequestPath = "",
    });

    var url = "http://127.0.0.1:8080";
    Console.WriteLine($"Starting web server at {url}");
    Console.WriteLine($"Serving files from: {outDir}");
    app.Run(url);
}
#endif
