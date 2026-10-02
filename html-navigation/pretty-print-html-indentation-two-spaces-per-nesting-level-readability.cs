// Pretty‑print the HTML with indentation of two spaces per nesting level for readability.

using System;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><head><title>Sample</title></head><body><h1>Hello World</h1><p>This is a paragraph.</p></body></html>";

            // Load HTML document using two‑argument constructor (content, baseUri)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Get the outer HTML of the document
                string rawHtml = document.DocumentElement.OuterHTML;

                // Pretty‑print with two‑space indentation
                string formattedHtml = PrettyPrintHtml(rawHtml);

                // Output the formatted HTML
                Console.WriteLine(formattedHtml);
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
        string[] tokens = Regex.Split(html, "(<[^>]+>)");

        foreach (string token in tokens)
        {
            if (string.IsNullOrWhiteSpace(token))
                continue;

            if (token.StartsWith("<"))
            {
                if (token.StartsWith("</"))
                {
                    indent = Math.Max(indent - 1, 0);
                    sb.AppendLine();
                    sb.Append(new string(' ', indent * 2));
                    sb.Append(token);
                }
                else if (token.EndsWith("/>"))
                {
                    sb.AppendLine();
                    sb.Append(new string(' ', indent * 2));
                    sb.Append(token);
                }
                else
                {
                    sb.AppendLine();
                    sb.Append(new string(' ', indent * 2));
                    sb.Append(token);
                    indent++;
                }
            }
            else
            {
                string text = token.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    sb.AppendLine();
                    sb.Append(new string(' ', indent * 2));
                    sb.Append(text);
                }
            }
        }

        return sb.ToString().Trim();
    }
}