using Xunit;

namespace Prism.SourceGenerators.Docs.Tests;

public class DocsLocaleTests
{
    [Theory]
    [InlineData("getting-started.md", "/getting-started/")]
    [InlineData("generators/index.md", "/generators/")]
    [InlineData("index.md", "/")]
    public void ToServedDirectoryPath_maps_markdown_to_directory_urls(string markdown, string expected)
    {
        Assert.Equal(expected, DocsLocale.ToServedDirectoryPath(markdown));
    }

    [Theory]
    [InlineData("getting-started.md", DocsLocale.Kind.ZhCn, "/zh-cn/getting-started/")]
    [InlineData("index.md", DocsLocale.Kind.Ja, "/ja/")]
    [InlineData("index.md", DocsLocale.Kind.English, "/")]
    public void ToServedDirectoryPathForLocale_adds_locale_prefix(string key, DocsLocale.Kind locale, string expected)
    {
        Assert.Equal(expected, DocsLocale.ToServedDirectoryPath(locale, key));
    }

    [Theory]
    [InlineData("zh-cn/getting-started.md", "getting-started.md")]
    [InlineData("ja/generators/index.md", "generators/index.md")]
    [InlineData("getting-started.md", "getting-started.md")]
    public void StripPrefix_removes_locale_directory(string input, string expected)
    {
        Assert.Equal(expected, DocsLocale.StripPrefix(input));
    }
}
