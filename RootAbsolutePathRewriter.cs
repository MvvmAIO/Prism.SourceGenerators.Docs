using System.Text;

/// <summary>Prefixes root-absolute site paths for GitHub project Pages subpath deployment.</summary>
public static class RootAbsolutePathRewriter
{
    private static readonly string[] Attributes = ["href", "src", "content"];

    public static string Apply(string content, string basePath)
    {
        if (string.IsNullOrEmpty(basePath))
        {
            return content;
        }

        var sb = new StringBuilder(content.Length + 64);
        var i = 0;
        while (i < content.Length)
        {
            var rewritten = false;
            for (var a = 0; a < Attributes.Length; a++)
            {
                var attr = Attributes[a];
                var needle = attr + "=\"/";
                if (i + needle.Length <= content.Length
                    && content.AsSpan(i, needle.Length).Equals(needle, StringComparison.Ordinal))
                {
                    var next = i + needle.Length;
                    if (next < content.Length && content[next] == '/')
                    {
                        break;
                    }

                    sb.Append(content, i, needle.Length - 1);
                    sb.Append(basePath);
                    i = next;
                    rewritten = true;
                    break;
                }
            }

            if (!rewritten)
            {
                sb.Append(content[i]);
                i++;
            }
        }

        return sb.ToString();
    }

    internal static byte[] Apply(ReadOnlySpan<byte> content, string basePath)
    {
        if (string.IsNullOrEmpty(basePath))
        {
            return content.ToArray();
        }

        var text = Encoding.UTF8.GetString(content);
        return Encoding.UTF8.GetBytes(Apply(text, basePath));
    }
}
