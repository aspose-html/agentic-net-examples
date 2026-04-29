// Convert HTML content to SVG using SvgSaveOptions.

using System;
using Aspose.Html;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Dom.Svg.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string htmlContent = "<html><body><svg width=\"100\" height=\"100\"><circle cx=\"50\" cy=\"50\" r=\"40\" stroke=\"green\" stroke-width=\"4\" fill=\"yellow\" /></svg></body></html>";

            // Temporary SVG file path
            string tempSvgPath = "temp.svg";

            // Final output SVG file path
            string outputSvgPath = "output.svg";

            // Base URI for the HTML document
            Url baseUri = new Url("https://example.com/");

            // Load HTML content into an HTMLDocument
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

            // Save the HTMLDocument as an intermediate SVG file
            document.Save(tempSvgPath);

            // Load the intermediate SVG file into an SVGDocument
            SVGDocument svgDoc = new SVGDocument(tempSvgPath);

            // Create SVG save options
            SVGSaveOptions options = new SVGSaveOptions();

            // Save the SVGDocument to the final SVG file using the options
            svgDoc.Save(outputSvgPath, options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}