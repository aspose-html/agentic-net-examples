// Detect and skip duplicate SVG markup by comparing OuterHTML strings before writing files.

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
            // Sample HTML containing SVG elements (some duplicates)
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'><circle cx='50' cy='50' r='40' fill='red'/></svg>" +
                                 "<svg width='100' height='100'><circle cx='50' cy='50' r='40' fill='red'/></svg>" +
                                 "<svg width='100' height='100'><rect width='100' height='100' fill='blue'/></svg>" +
                                 "</body></html>";

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlContent);

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Track seen SVG markup to skip duplicates
            HashSet<string> seenMarkups = new HashSet<string>();

            // Ensure output directory exists
            string outputDir = "output_svgs";
            Directory.CreateDirectory(outputDir);

            // Iterate through SVG elements
            for (int i = 0; i < svgs.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip if this markup has already been processed
                if (!seenMarkups.Add(markup))
                    continue;

                // Define output file path
                string fileName = $"svg_{i}.svg";
                string outputPath = Path.Combine(outputDir, fileName);

                // Create SVG document from markup and save
                SVGDocument svgDoc = new SVGDocument(markup, "");
                svgDoc.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}