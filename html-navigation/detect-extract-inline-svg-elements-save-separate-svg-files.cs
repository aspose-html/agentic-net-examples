// Detect and extract all inline SVG elements and save them as separate .svg files.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content containing inline SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg>" +
                                 "<svg width='50' height='50'><rect width='50' height='50' style='fill:blue;'/></svg>" +
                                 "</body></html>";

            // Load HTML document from the string (using a dummy base URI)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Keep track of already processed SVG markup to avoid duplicates
            System.Collections.Generic.HashSet<string> seenMarkups = new System.Collections.Generic.HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicate SVGs
                if (!seenMarkups.Add(markup))
                    continue;

                // Prepare output file path
                string fileName = $"svg_{i}.svg";
                string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), fileName);

                // Create an SVG document from the markup and save it
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(outputPath);
            }

            System.Console.WriteLine("SVG extraction completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}