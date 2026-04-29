// Load an SVG file from a local path into an SVGDocument instance.

using System;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Local SVG file path
            string svgPath = "input.svg";

            // Load the SVG file into an SVGDocument instance
            using (SVGDocument doc = new SVGDocument(svgPath))
            {
                // The SVGDocument is now loaded and can be used here
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}