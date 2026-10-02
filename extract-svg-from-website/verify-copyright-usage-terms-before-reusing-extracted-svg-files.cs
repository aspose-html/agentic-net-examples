// Verify copyright and usage terms before reusing extracted SVG files.

using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" +
                                 "<svg width=\"100\" height=\"100\"><rect width=\"80\" height=\"80\" x=\"10\" y=\"10\" style=\"fill:blue;stroke:black;stroke-width:2\"/></svg>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" + // duplicate
                                 "</body></html>";

            // Load HTML document from inline content
            string baseUri = "about:blank";
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Track unique SVG markup
            HashSet<string> seenMarkups = new HashSet<string>();

            // Ensure output directory exists
            string outputDir = "ExtractedSvgs";
            Directory.CreateDirectory(outputDir);

            for (int i = 0; i < svgs.Length; i++)
            {
                // Cast to HTMLElement to access OuterHTML
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicates
                if (!seenMarkups.Add(markup))
                    continue;

                // Save each unique SVG to a file
                string outputPath = Path.Combine(outputDir, $"svg_{i}.svg");
                SVGDocument svgDoc = new SVGDocument(markup, baseUri);
                svgDoc.Save(outputPath);

                Console.WriteLine($"Saved SVG to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}