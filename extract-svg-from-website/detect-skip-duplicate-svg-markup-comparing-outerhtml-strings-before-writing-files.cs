// Detect and skip duplicate SVG markup by comparing OuterHTML strings before writing files.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML containing duplicate SVG markup
            string htmlContent = "<html><body>" +
                "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" +
                "<p>Some text</p>" +
                "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"black\" stroke-width=\"3\" fill=\"red\" /></svg>" + // duplicate
                "<svg width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" style=\"fill:blue\"/></svg>" +
                "</body></html>";

            // Load HTML from inline content using two‑argument constructor
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Track seen SVG markup to skip duplicates
            System.Collections.Generic.HashSet<string> seenMarkups = new System.Collections.Generic.HashSet<string>();

            // Prepare output directory
            string outputDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "output");
            System.IO.Directory.CreateDirectory(outputDir);

            int savedIndex = 0;

            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;

                // Skip if this markup has already been processed
                if (!seenMarkups.Add(markup))
                {
                    continue;
                }

                string outputPath = System.IO.Path.Combine(outputDir, $"svg_{savedIndex}.svg");
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(outputPath);
                savedIndex++;
            }

            Console.WriteLine($"Extracted {savedIndex} unique SVG(s) to \"{outputDir}\".");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}