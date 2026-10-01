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
            string htmlContent = @"<!DOCTYPE html>
<html>
<head>
    <title> Sample Page </title>
    <style>
        body { font-family: Arial; }
    </style>
</head>
<body>
    <h1>   Hello World!   </h1>
    <p>This is a    paragraph with    extra spaces.</p>
    <ul>
        <li>Item 1</li>
        <li>Item 2</li>
    </ul>
</body>
</html>";

            // Load HTML into Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get the original outer HTML
            string originalHtml = document.DocumentElement.OuterHTML;

            // Collapse whitespace
            string minified = Regex.Replace(originalHtml, @"\s+", " ");

            // Remove optional closing tags (common ones)
            string[] optionalClosingTags = new string[]
            {
                "</p>", "</li>", "</dt>", "</dd>", "</option>", "</thead>", "</tbody>",
                "</tfoot>", "</tr>", "</th>", "</td>", "</colgroup>", "</col>"
            };
            foreach (string tag in optionalClosingTags)
            {
                minified = minified.Replace(tag, string.Empty);
            }

            // Trim leading/trailing spaces
            minified = minified.Trim();

            Console.WriteLine("Original HTML:");
            Console.WriteLine(originalHtml);
            Console.WriteLine();
            Console.WriteLine("Minified HTML:");
            Console.WriteLine(minified);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}