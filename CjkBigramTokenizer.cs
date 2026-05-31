using System.Text;

/// <summary>Bigram tokenization for CJK text to improve Lunr search without lunr-languages.</summary>
public static class CjkBigramTokenizer
{
    public static bool ContainsCjk(string text)
    {
        for (var i = 0; i < text.Length; i++)
        {
            if (IsCjk(text[i]))
            {
                return true;
            }
        }

        return false;
    }

    public static string Apply(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return text;
        }

        var sb = new StringBuilder(text.Length * 2);
        var i = 0;
        while (i < text.Length)
        {
            if (!IsCjk(text[i]))
            {
                sb.Append(text[i]);
                i++;
                continue;
            }

            var start = i;
            while (i < text.Length && IsCjk(text[i]))
            {
                i++;
            }

            var run = text[start..i];
            if (run.Length == 1)
            {
                sb.Append(run);
            }
            else
            {
                sb.Append(' ');
                for (var b = 0; b < run.Length - 1; b++)
                {
                    if (b > 0)
                    {
                        sb.Append(' ');
                    }

                    sb.Append(run.AsSpan(b, 2));
                }

                sb.Append(' ');
            }
        }

        return sb.ToString();
    }

    private static bool IsCjk(char c) =>
        c is >= '\u4E00' and <= '\u9FFF'
            or >= '\u3400' and <= '\u4DBF'
            or >= '\u3040' and <= '\u30FF'
            or >= '\uAC00' and <= '\uD7AF';
}
