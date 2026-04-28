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
            // Path to the source HTML file
            string inputPath = "input.html";
            // Path where the minified HTML will be saved
            string outputPath = "output.min.html";

            // Load the HTML document from the file
            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                // Get the full markup of the document
                string html = document.DocumentElement.OuterHTML;

                // Collapse multiple whitespace characters into a single space
                string minified = Regex.Replace(html, @"\s+", " ");
                // Remove whitespace between tags
                minified = Regex.Replace(minified, @">\s+<", "><");
                // Remove optional closing tags (e.g., </p>, </li>, etc.)
                minified = Regex.Replace(minified, @"</(p|li|dt|dd|option|thead|tbody|tfoot|tr|th|td)>", "", RegexOptions.IgnoreCase);

                // Replace the document's content with the minified markup
                document.DocumentElement.OuterHTML = minified;
                // Save the minified document to the specified file
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}