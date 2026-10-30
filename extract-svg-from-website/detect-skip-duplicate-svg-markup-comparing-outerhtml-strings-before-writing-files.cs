// Detect and skip duplicate SVG markup by comparing OuterHTML strings before writing files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing SVG elements (some duplicates)
            string htmlContent = @"
                <html>
                <body>
                    <svg width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>
                    <svg width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>
                    <svg width='120' height='120'><rect width='100' height='100' fill='green' /></svg>
                </body>
                </html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            // Track seen SVG markup to skip duplicates
            System.Collections.Generic.HashSet<string> seenMarkups = new System.Collections.Generic.HashSet<string>();

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip if this markup was already processed
                if (!seenMarkups.Add(markup))
                {
                    continue;
                }

                string outputPath = System.IO.Path.Combine(outputDir, $"svg_{i}.svg");

                // Create SVG document from markup and save
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(outputPath);
            }

            System.Console.WriteLine("SVG extraction completed. Files saved to: " + outputDir);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}