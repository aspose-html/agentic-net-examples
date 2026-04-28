// Detect and extract all inline SVG elements and save them as separate .svg files.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

namespace SvgExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Source HTML location (URL or local file path)
                string source = args.Length > 0 ? args[0] : "https://example.com/page.html";

                // Directory where extracted SVG files will be saved
                string outputDir = args.Length > 1 ? args[1] : Environment.CurrentDirectory;

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(source);

                // Retrieve all inline <svg> elements
                HTMLCollection svgs = document.GetElementsByTagName("svg");

                // Iterate through each SVG element
                for (int i = 0; i < svgs.Length; i++)
                {
                    // Cast the node to HTMLElement to access OuterHTML
                    HTMLElement svgElement = (HTMLElement)svgs[i];
                    string markup = svgElement.OuterHTML;

                    // Generate a unique file name for each SVG
                    string fileName = System.IO.Path.Combine(outputDir, $"svg_{i}.svg");

                    // Create an SVGDocument from the markup with the base URI
                    SVGDocument svgDoc = new SVGDocument(markup, source);

                    // Save the SVG to the file system
                    svgDoc.Save(fileName);
                }

                Console.WriteLine($"Extracted {svgs.Length} SVG(s) to '{outputDir}'.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}