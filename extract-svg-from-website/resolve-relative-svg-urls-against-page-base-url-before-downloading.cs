// Resolve relative SVG URLs against the page's base URL before downloading.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths and base URL
            string svgPath = "sample.svg";
            string baseUrl = "https://example.com/assets/";
            string outputPath = "resolved.svg";

            // Create a minimal SVG with a relative image reference
            string svgContent = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""200"">" +
                                @"<image href=""images/pic.png"" width=""100"" height=""100""/>" +
                                @"</svg>";

            // Write the SVG content to a file
            File.WriteAllText(svgPath, svgContent);

            // Load the SVG document with the base URL to resolve relative URLs
            Aspose.Html.Dom.Svg.SVGDocument svgDoc = new Aspose.Html.Dom.Svg.SVGDocument(svgPath, baseUrl);

            // Save the resolved SVG to the output file
            svgDoc.Save(outputPath);

            Console.WriteLine($"SVG saved to '{outputPath}' with relative URLs resolved against base URL.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}