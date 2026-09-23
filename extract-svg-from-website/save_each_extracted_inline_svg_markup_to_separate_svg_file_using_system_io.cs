// Save each extracted inline SVG markup to a separate .svg file using System.IO.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML with inline SVG elements
            string htmlContent = "<html><body>" +
                                 "<svg width='100' height='100'><circle cx='50' cy='50' r='40' stroke='green' fill='yellow'/></svg>" +
                                 "<svg width='50' height='50'><rect width='50' height='50' style='fill:blue;'/></svg>" +
                                 "</body></html>";

            // Load HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all SVG elements
            Aspose.Html.Collections.HTMLCollection svgs = document.GetElementsByTagName("svg");

            // Extract each SVG and save to a separate .svg file
            for (int i = 0; i < svgs.Length; i++)
            {
                Aspose.Html.HTMLElement svgElement = (Aspose.Html.HTMLElement)svgs[i];
                string markup = svgElement.OuterHTML;
                string fileName = $"svg_{i}.svg";
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

                using (Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(markup, ""))
                {
                    svgDoc.Save(outputPath);
                }

                Console.WriteLine($"Saved SVG #{i} to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}