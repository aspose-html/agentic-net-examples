// Verify copyright and usage terms before reusing extracted SVG files.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file with SVG elements
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Sample SVGs</title></head>
<body>
    <svg width=""100"" height=""100"" data-license=""CC-BY-4.0"">
        <circle cx=""50"" cy=""50"" r=""40"" stroke=""green"" stroke-width=""4"" fill=""yellow"" />
    </svg>
    <svg width=""200"" height=""200"">
        <rect width=""200"" height=""200"" style=""fill:blue;stroke:pink;stroke-width:5;opacity:0.5"" />
    </svg>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Get all SVG elements
            HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Track processed SVG markup to avoid duplicates
            HashSet<string> seenMarkups = new HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                HTMLElement svgElement = (HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicate SVGs
                if (!seenMarkups.Add(markup))
                    continue;

                // Verify usage terms (e.g., presence of a data-license attribute)
                string license = svgElement.GetAttribute("data-license");
                if (string.IsNullOrEmpty(license))
                {
                    Console.WriteLine($"Warning: SVG #{i + 1} does not specify a usage license.");
                }
                else
                {
                    Console.WriteLine($"SVG #{i + 1} license: {license}");
                }

                // Save the SVG to a separate file
                string outputPath = $"extracted_svg_{i + 1}.svg";
                SVGDocument svgDoc = new SVGDocument(markup, "about:blank");
                svgDoc.Save(new Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler(outputPath));

                Console.WriteLine($"Saved SVG #{i + 1} to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}