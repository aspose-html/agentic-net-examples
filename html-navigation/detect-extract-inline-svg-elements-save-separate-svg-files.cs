// Detect and extract all inline SVG elements and save them as separate .svg files.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with inline SVG elements
            string html = "<html><body>" +
                          "<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' /></svg>" +
                          "<p>Some text</p>" +
                          "<svg width='50' height='50'><rect width='50' height='50' style='fill:blue;'/></svg>" +
                          "</body></html>";

            // Load HTML document from string (inline content)
            HTMLDocument document = new HTMLDocument(html, "about:blank");

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare output directory
            string outputDir = "output_svgs";
            Directory.CreateDirectory(outputDir);

            // Track processed SVG markup to avoid duplicates
            HashSet<string> seenMarkups = new HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicate SVGs
                if (!seenMarkups.Add(markup))
                    continue;

                string fileName = $"svg_{i}.svg";
                string filePath = Path.Combine(outputDir, fileName);

                // Create SVG document from markup and save to file
                SVGDocument svgDoc = new SVGDocument(markup, "about:blank");
                svgDoc.Save(filePath);
            }

            Console.WriteLine("SVG extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}