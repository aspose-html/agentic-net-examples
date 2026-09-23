// Iterate over the returned SVG collection.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Create a minimal HTML file with SVG elements
            string htmlPath = "sample.html";
            string htmlContent = "<html><body><svg width='100' height='100'></svg><div>text</div><svg></svg></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over the SVG collection
            for (int i = 0; i < svgs.Length; i++)
            {
                var node = svgs[i];
                Console.WriteLine($"SVG {i}: NodeName = {node.NodeName}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}