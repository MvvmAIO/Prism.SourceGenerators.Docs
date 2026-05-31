using Xunit;

namespace Prism.SourceGenerators.Docs.Tests;

public class CjkBigramTokenizerTests
{
    [Fact]
    public void Apply_splits_cjk_runs_into_bigrams()
    {
        var result = CjkBigramTokenizer.Apply("可观察属性");
        Assert.Contains("可观", result);
        Assert.Contains("观察", result);
        Assert.Contains("察属", result);
        Assert.Contains("属性", result);
    }

    [Fact]
    public void Apply_leaves_ascii_unchanged()
    {
        const string input = "ObservableProperty";
        Assert.Equal(input, CjkBigramTokenizer.Apply(input));
    }

    [Theory]
    [InlineData("hello", false)]
    [InlineData("可观察", true)]
    [InlineData("プロパティ", true)]
    public void ContainsCjk_detects_cjk_text(string input, bool expected)
    {
        Assert.Equal(expected, CjkBigramTokenizer.ContainsCjk(input));
    }
}
