// Minify the HTML document by collapsing whitespace and removing optional closing tags.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html>\n<html>\n<head>\n<title> Test </title>\n</head>\n<body>\n<div>\n<p>   Hello   World!   </p>\n<ul>\n<li>Item 1</li>\n<li>Item 2</li>\n</ul>\n</div>\n</body>\n</html>";
            // Load the HTML document from the inline string
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");
            // Get the original HTML
            string originalHtml = document.DocumentElement.OuterHTML;
            // Collapse whitespace
            string minified = Regex.Replace(originalHtml, @"\s+", " ");
            // Remove optional closing tags
            string[] optionalTags = new string[] { "html", "head", "body", "p", "li", "dt", "dd", "option", "colgroup", "tbody", "thead", "tfoot", "tr", "th", "td" };
            foreach (string tag in optionalTags)
            {
                minified = Regex.Replace(minified, $@"</{tag}>", "", RegexOptions.IgnoreCase);
            }
            minified = minified.Trim();
            // Save the minified HTML to a file
            string outputPath = "minified.html";
            File.WriteAllText(outputPath, minified);
            Console.WriteLine("Minified HTML saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}