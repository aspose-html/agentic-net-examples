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
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello</h1><p>World<span>!</span></p></body></html>";
            string baseUri = "http://example.com/";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            string rawHtml = document.DocumentElement.OuterHTML;
            string prettyHtml = PrettyPrint(rawHtml);

            Console.WriteLine(prettyHtml);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static string PrettyPrint(string html)
    {
        var sb = new StringBuilder();
        int indent = 0;
        bool inTag = false;
        for (int i = 0; i < html.Length; i++)
        {
            char c = html[i];
            if (c == '<')
            {
                // Determine if this is a closing tag
                bool isClosing = i + 1 < html.Length && html[i + 1] == '/';
                // Determine if this is a self‑closing tag (ends with "/>")
                int tagEnd = html.IndexOf('>', i);
                bool isSelfClosing = tagEnd > i && html[tagEnd - 1] == '/';

                if (isClosing)
                {
                    indent = Math.Max(indent - 1, 0);
                }

                sb.AppendLine();
                sb.Append(new string(' ', indent * 2));
                inTag = true;
            }

            sb.Append(c);

            if (c == '>' && inTag)
            {
                // After completing a tag, adjust indent for opening tags
                bool isClosingTag = i > 0 && html[i - 1] == '/';
                bool isSelfClosingTag = false;
                // Check for self‑closing pattern "/>"
                if (i > 0 && html[i - 1] == '/' && (i - 2 >= 0 && html[i - 2] != '<'))
                {
                    isSelfClosingTag = true;
                }

                if (!isClosingTag && !isSelfClosingTag && !(i > 0 && html[i - 1] == '/' && html[i - 2] == '<'))
                {
                    // Opening tag that is not self‑closing
                    indent++;
                }

                inTag = false;
            }
        }

        return sb.ToString().Trim();
    }
}