// Pretty‑print the HTML with indentation of two spaces per nesting level for readability.

using System;
using System.Text;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello</h1><p>World</p></body></html>";

            // Load HTML content into Aspose.HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Get the raw HTML from the document
                string rawHtml = document.DocumentElement.OuterHTML;

                // Pretty‑print the HTML with two‑space indentation
                string prettyHtml = PrettyPrintHtml(rawHtml);

                // Output the formatted HTML
                Console.WriteLine(prettyHtml);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string PrettyPrintHtml(string html)
    {
        var sb = new StringBuilder();
        int indent = 0;
        int i = 0;
        while (i < html.Length)
        {
            if (html[i] == '<')
            {
                // Find the end of the tag
                int tagEnd = html.IndexOf('>', i);
                if (tagEnd == -1) break;

                string tag = html.Substring(i, tagEnd - i + 1);
                bool isClosingTag = tag.StartsWith("</");
                bool isSelfClosing = tag.EndsWith("/>") || tag.StartsWith("<!") || tag.StartsWith("<?");

                if (isClosingTag)
                {
                    indent = Math.Max(indent - 2, 0);
                    AppendNewLineAndIndent(sb, indent);
                    sb.Append(tag);
                }
                else if (isSelfClosing)
                {
                    AppendNewLineAndIndent(sb, indent);
                    sb.Append(tag);
                }
                else
                {
                    AppendNewLineAndIndent(sb, indent);
                    sb.Append(tag);
                    indent += 2;
                }

                i = tagEnd + 1;
            }
            else
            {
                // Text content
                int textStart = i;
                while (i < html.Length && html[i] != '<')
                    i++;

                string text = html.Substring(textStart, i - textStart).Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    AppendNewLineAndIndent(sb, indent);
                    sb.Append(text);
                }
            }
        }

        return sb.ToString();
    }

    static void AppendNewLineAndIndent(StringBuilder sb, int indent)
    {
        sb.AppendLine();
        sb.Append(new string(' ', indent));
    }
}