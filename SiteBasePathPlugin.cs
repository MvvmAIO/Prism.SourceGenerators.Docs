using System.Buffers;
using System.Text;
using NuStreamDocs.Plugins;

/// <summary>
/// Prefixes root-absolute paths in HTML and search JSON for GitHub project Pages subpath deployment.
/// </summary>
internal sealed class SiteBasePathPlugin : IPlugin, IPagePostRenderPlugin, IBuildFinalizePlugin
{
    private readonly string _basePath;

    public SiteBasePathPlugin(DocsBuildSettings settings)
    {
        _basePath = settings.BasePath;
    }

    public ReadOnlySpan<byte> Name => "site-base-path"u8;

    public PluginPriority PostRenderPriority => new(PluginBand.Latest, 300);

    public PluginPriority FinalizePriority => new(PluginBand.Latest, 200);

    public bool NeedsRewrite(ReadOnlySpan<byte> html) =>
        !string.IsNullOrEmpty(_basePath) && html.IndexOf("=\"/"u8) >= 0;

    public void PostRender(in PagePostRenderContext context)
    {
        if (string.IsNullOrEmpty(_basePath))
        {
            WriteAll(context.Output, context.Html);
            return;
        }

        var text = Encoding.UTF8.GetString(context.Html);
        var rewritten = RootAbsolutePathRewriter.Apply(text, _basePath);
        WriteAll(context.Output, Encoding.UTF8.GetBytes(rewritten));
    }

    public ValueTask FinalizeAsync(BuildFinalizeContext context, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_basePath))
        {
            return default;
        }

        var outputRoot = context.OutputRoot.ToString();
        RewriteJsonFiles(outputRoot);
        return default;
    }

    private void RewriteJsonFiles(string outputRoot)
    {
        var searchDir = Path.Combine(outputRoot, "search");
        if (!Directory.Exists(searchDir))
        {
            return;
        }

        foreach (var file in Directory.EnumerateFiles(searchDir, "*.json", SearchOption.AllDirectories))
        {
            var text = File.ReadAllText(file);
            var rewritten = RewriteSearchJson(text, _basePath);
            rewritten = RootAbsolutePathRewriter.Apply(rewritten, _basePath);
            if (!string.Equals(text, rewritten, StringComparison.Ordinal))
            {
                File.WriteAllText(file, rewritten);
            }
        }
    }

    private static string RewriteSearchJson(string content, string basePath)
    {
        if (string.IsNullOrEmpty(basePath))
        {
            return content;
        }

        return content.Replace("\"location\":\"/", $"\"location\":\"{basePath}", StringComparison.Ordinal);
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
