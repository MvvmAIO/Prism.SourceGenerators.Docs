using Xunit;

namespace Prism.SourceGenerators.Docs.Tests;

public class RootAbsolutePathRewriterTests
{
    private const string Base = "/Prism.SourceGenerators.Docs/";

    [Fact]
    public void Apply_prefixes_href_src_and_content()
    {
        const string input = "<a href=\"/getting-started/\"><img src=\"/assets/x.svg\"><meta content=\"/search/index.json\">";
        var result = RootAbsolutePathRewriter.Apply(input, Base);
        Assert.Contains("href=\"/Prism.SourceGenerators.Docs/getting-started/\"", result);
        Assert.Contains("src=\"/Prism.SourceGenerators.Docs/assets/x.svg\"", result);
        Assert.Contains("content=\"/Prism.SourceGenerators.Docs/search/index.json\"", result);
    }

    [Fact]
    public void Apply_skips_protocol_relative_urls()
    {
        const string input = "<link href=\"//cdn.example.com/lib.css\">";
        var result = RootAbsolutePathRewriter.Apply(input, Base);
        Assert.Equal(input, result);
    }

    [Fact]
    public void Apply_returns_unchanged_when_base_path_empty()
    {
        const string input = "<a href=\"/page/\">";
        Assert.Equal(input, RootAbsolutePathRewriter.Apply(input, string.Empty));
    }
}
