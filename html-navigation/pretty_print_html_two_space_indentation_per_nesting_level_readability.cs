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

            // Load HTML into document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, ""))
            {
                // Get raw outer HTML
                string rawHtml = document.DocumentElement.OuterHTML;

                // Pretty‑print with two‑space indentation
                string prettyHtml = PrettyPrintHtml(rawHtml, 2);

                // Output result
                Console.WriteLine(prettyHtml);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static string PrettyPrintHtml(string html, int indentSize)
    {
        var sb = new StringBuilder();
        int indent = 0;

        for (int i = 0; i < html.Length; i++)
        {
            if (html[i] == '<')
            {
                bool isClosingTag = i + 1 < html.Length && html[i + 1] == '/';
                if (isClosingTag)
                    indent = Math.Max(indent - 1, 0);

                sb.Append('\n');
                sb.Append(new string(' ', indent * indentSize));

                // Append the whole tag
                while (i < html.Length && html[i] != '>')
                {
                    sb.Append(html[i]);
                    i++;
                }
                if (i < html.Length)
                    sb.Append('>');

                bool isSelfClosing = i - 1 >= 0 && html[i - 1] == '/';
                if (!isClosingTag && !isSelfClosing)
                    indent++;
            }
            else
            {
                sb.Append(html[i]);
            }
        }

        return sb.ToString().TrimStart('\n');
    }
}