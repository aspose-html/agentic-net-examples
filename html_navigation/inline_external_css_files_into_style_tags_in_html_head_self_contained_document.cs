// Inline external CSS files into style tags within the HTML head for a self‑contained document.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Css;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the source HTML file and the output self‑contained HTML file
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(inputPath);

            // Get all <link> elements in the document
            var linkElements = document.GetElementsByTagName("link");

            // Iterate over a copy of the collection because we will modify the DOM
            foreach (Element link in linkElements)
            {
                // Process only stylesheet links
                if (string.Equals(link.GetAttribute("rel"), "stylesheet", StringComparison.OrdinalIgnoreCase))
                {
                    string href = link.GetAttribute("href");
                    if (string.IsNullOrEmpty(href))
                        continue;

                    // Resolve the CSS file path relative to the HTML file location
                    string cssPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? string.Empty, href);
                    if (!File.Exists(cssPath))
                        continue;

                    // Read the external CSS content
                    string cssContent = File.ReadAllText(cssPath);

                    // Create a new <style> element and set its content
                    Element style = document.CreateElement("style");
                    style.TextContent = cssContent;

                    // Replace the <link> element with the newly created <style> element
                    Node parent = link.ParentNode;
                    if (parent != null)
                        parent.ReplaceChild(style, link);
                }
            }

            // Save the modified document as a self‑contained HTML file
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}