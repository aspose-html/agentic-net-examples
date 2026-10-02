// Minify the HTML document by collapsing whitespace and removing optional closing tags.

using System;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n    <title> Sample Page </title>\n</head>\n<body>\n    <p>   This is   a   paragraph.   </p>\n    <ul>\n        <li>Item 1</li>\n        <li>Item 2</li>\n    </ul>\n</body>\n</html>";

            // Load HTML into Aspose.HTML document (use two-argument constructor with a dummy base URI)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get the original outer HTML
            string originalHtml = document.DocumentElement.OuterHTML;

            // Collapse whitespace between tags
            string collapsed = Regex.Replace(originalHtml, @">\s+<", "><");

            // Replace multiple whitespace characters with a single space
            collapsed = Regex.Replace(collapsed, @"\s{2,}", " ");

            // Remove optional closing tags (common HTML optional tags)
            string pattern = @"</(li|p|tr|td|th|option|thead|tbody|tfoot|colgroup|caption)>";
            string minified = Regex.Replace(collapsed, pattern, "", RegexOptions.IgnoreCase);

            // Output results
            Console.WriteLine("Original HTML:");
            Console.WriteLine(originalHtml);
            Console.WriteLine("\nMinified HTML:");
            Console.WriteLine(minified);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}