// Save each extracted inline SVG markup to a separate .svg file using System.IO.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with inline SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg>" +
                                 "<svg width=\"50\" height=\"50\"><rect width=\"50\" height=\"50\" style=\"fill:blue\"/></svg>" +
                                 "</body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Ensure output directory exists
            string outputDir = "output_svgs";
            System.IO.Directory.CreateDirectory(outputDir);

            // Extract each SVG and save to a separate .svg file
            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string filePath = System.IO.Path.Combine(outputDir, $"svg_{i}.svg");

                // Create SVG document from markup and save
                Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, "about:blank");
                svgDoc.Save(filePath);
            }

            System.Console.WriteLine("SVG extraction completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}