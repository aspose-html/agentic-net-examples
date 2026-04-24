// Resolve relative SVG URLs against the page's base URL before downloading.

using System;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // SVG markup containing a relative URL (e.g., an image reference)
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"200\">" +
                                "<image href=\"images/pic.png\" width=\"200\" height=\"200\"/></svg>";

            // Base URL of the page that the SVG is embedded in
            string baseUri = "https://example.com/assets/";

            // Load the SVG document with the base URI so that relative URLs are resolved
            SVGDocument svgDoc = new SVGDocument(svgContent, baseUri);

            // Save the resolved SVG to a local file
            string outputPath = "resolved.svg";
            svgDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}