// Iterate over the returned SVG collection.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg>" +
                                 "<svg width='50' height='50'><rect width='50' height='50' style='fill:blue;'/></svg>" +
                                 "</body></html>";

            // Load HTML from string (use two-argument constructor)
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Iterate over the collection and save each SVG to a separate file
            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast the node to HTMLElement to access OuterHTML
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string svgContent = svgElement.OuterHTML;

                string fileName = $"{i}.svg";
                File.WriteAllText(fileName, svgContent);
                Console.WriteLine($"Saved SVG #{i} to '{fileName}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}