// Load an SVG file from a local path into an SVGDocument instance.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            // Output file path
            string outputPath = "output.svg";

            // Create SVGDocument from string content
            using (Aspose.Html.Dom.Svg.SVGDocument doc = new Aspose.Html.Dom.Svg.SVGDocument(string.Empty, svgContent))
            {
                // Save the SVG document to a file
                doc.Save(outputPath);
            }

            Console.WriteLine($"SVG document saved to: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}