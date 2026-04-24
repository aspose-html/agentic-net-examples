// Extract each inline SVG's markup via the OuterHTML property.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

namespace ExtractInlineSvg
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the HTML file containing inline SVGs
                string htmlPath = "input.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Get all <svg> elements
                HTMLCollection svgs = document.GetElementsByTagName("svg");

                // Iterate through each SVG element
                for (int i = 0; i < svgs.Length; i++)
                {
                    // Cast the node to HTMLElement to access OuterHTML
                    HTMLElement svgElement = (HTMLElement)svgs[i];

                    // Extract the SVG markup
                    string markup = svgElement.OuterHTML;

                    // Define a file name for the extracted SVG
                    string fileName = $"svg_{i}.svg";

                    // Create an SVGDocument from the markup (base URI is the HTML file path)
                    SVGDocument svgDoc = new SVGDocument(markup, htmlPath);

                    // Save the SVG to a separate file
                    svgDoc.Save(fileName);
                }

                Console.WriteLine("Extraction completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}