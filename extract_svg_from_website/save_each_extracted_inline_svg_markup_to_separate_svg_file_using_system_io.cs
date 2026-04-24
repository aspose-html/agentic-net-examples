// Save each extracted inline SVG markup to a separate .svg file using System.IO.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTML page containing inline SVG elements
            string url = "https://example.com/page-with-svgs.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(url);

            // Get all <svg> elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Ensure output directory exists
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Iterate over each SVG element
            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast the collection item to HTMLElement
                HTMLElement svgElement = (HTMLElement)svgs[i];

                // Extract the outer HTML markup of the SVG
                string markup = svgElement.OuterHTML;

                // Build a unique file name for each SVG
                string fileName = Path.Combine(outputDir, $"svg_{i}.svg");

                // Create an SVGDocument from the markup and base URI
                SVGDocument svgDoc = new SVGDocument(markup, url);

                // Save the SVG to a file
                svgDoc.Save(fileName);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}