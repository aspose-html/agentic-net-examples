// Load an SVG file from the local file system for conversion.

using System;
using Aspose.Html.Dom.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the SVG file on the local file system
            string svgPath = "input.svg";

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Document loaded successfully
            Console.WriteLine("SVG file loaded successfully.");
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during loading
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}