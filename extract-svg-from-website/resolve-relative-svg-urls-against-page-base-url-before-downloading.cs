// Resolve relative SVG URLs against the page's base URL before downloading.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Base URL of the HTML page
            string baseUrl = "https://example.com/pages/";
            // Relative SVG URL found in the page
            string relativeSvg = "images/sample.svg";

            // Resolve the relative URL against the base URL
            string absoluteSvgUrl = new Uri(new Uri(baseUrl), relativeSvg).ToString();

            // Load the SVG document using the resolved absolute URL
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(absoluteSvgUrl, baseUrl);

            // Save the SVG to a local file
            string outputPath = "resolved.svg";
            svgDoc.Save(outputPath);

            Console.WriteLine($"SVG saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}