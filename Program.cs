using NuStreamDocs.Building;
using NuStreamDocs.Config.MkDocs;
using NuStreamDocs.Highlight;
using NuStreamDocs.MarkdownExtensions;
using NuStreamDocs.Nav;
using NuStreamDocs.Search.Lunr;
using NuStreamDocs.Sitemap;
using NuStreamDocs.Theme.Material3;
using NuStreamDocs.Toc;

// ASP.NET Core imports for development server
#if DEBUG
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.StaticFiles;
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
var siteUrl = Environment.GetEnvironmentVariable("DOCS_SITE_URL")?.Trim();
if (string.IsNullOrEmpty(siteUrl))
{
    siteUrl = "https://mvvmaio.github.io/Prism.SourceGenerators.Docs/";
}

var docsDir = ResolveContentPath("docs");
var mkdocsFile = ResolveContentPath("mkdocs.yml");
var responsiveCss = ResolveContentPath(Path.Combine("styles", "responsive.css"));

var configured = new DocBuilder()
    .WithInput(docsDir)
    .WithOutput(outDir)
    .WithSiteUrl(siteUrl)
    .UseDirectoryUrls()
    .UseMkDocsConfig(mkdocsFile)
    .UseMaterial3Theme()
    .UsePlugin(new HeaderLanguageSwitcherPlugin());

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

// Check if we should start a web server for development
#if DEBUG
if (args.Length > 1 && args[1] == "--serve")
{
    var builder = WebApplication.CreateBuilder(args);
    
    var app = builder.Build();
    
    // Redirect root to homepage
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/")
        {
            context.Response.Redirect("/index.html");
            return;
        }
        await next();
    });
    
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(outDir),
        RequestPath = ""
    });
    
    var url = "http://127.0.0.1:8080";
    Console.WriteLine($"Starting web server at {url}");
    Console.WriteLine($"Serving files from: {outDir}");
    Console.WriteLine($"Root / redirects to /index.html");
    app.Run(url);
}
#endif
