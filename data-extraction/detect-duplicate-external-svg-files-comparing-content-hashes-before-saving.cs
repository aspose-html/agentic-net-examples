// Detect duplicate external SVG files by comparing content hashes before saving.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing SVG elements (two duplicates, one unique)
            string htmlContent = @"
                <html>
                    <body>
                        <svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>
                        <svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='black' stroke-width='3' fill='red' /></svg>
                        <svg width='100' height='100'><rect width='80' height='80' x='10' y='10' fill='green' /></svg>
                    </body>
                </html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Track unique SVG markup
            HashSet<string> seenMarkups = new HashSet<string>();

            // Prepare output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output_svgs");
            Directory.CreateDirectory(outputDir);

            int index = 1;
            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip duplicates
                if (!seenMarkups.Add(markup))
                    continue;

                string outputPath = Path.Combine(outputDir, $"svg_{index}.svg");
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(outputPath);
                index++;
            }

            Console.WriteLine("Unique SVG files have been saved to: " + outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}