// Verify copyright and usage terms before reusing extracted SVG files.

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
            // Sample HTML content containing SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width=\"100\" height=\"100\" xmlns=\"http://www.w3.org/2000/svg\">" +
                                 "<rect width=\"100\" height=\"100\" style=\"fill:blue\"/>" +
                                 "<!-- copyright: Example Corp -->" +
                                 "</svg>" +
                                 "<svg width=\"50\" height=\"50\" xmlns=\"http://www.w3.org/2000/svg\">" +
                                 "<circle cx=\"25\" cy=\"25\" r=\"20\" style=\"fill:red\"/>" +
                                 "<!-- copyright: Example Corp -->" +
                                 "</svg>" +
                                 "</body></html>";

            // Load HTML document from the string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare output directory
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            // Track processed SVG markup to avoid duplicates
            System.Collections.Generic.HashSet<string> seenMarkups = new System.Collections.Generic.HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicate SVGs
                if (!seenMarkups.Add(markup))
                    continue;

                // Verify copyright or usage terms in the SVG markup
                if (!markup.Contains("copyright"))
                {
                    // Skip SVGs without explicit copyright information
                    continue;
                }

                // Save each verified SVG to a separate file
                string outputPath = System.IO.Path.Combine(outputDir, $"svg_{i}.svg");
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "");
                svgDoc.Save(outputPath);
            }

            Console.WriteLine("SVG extraction and verification completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}