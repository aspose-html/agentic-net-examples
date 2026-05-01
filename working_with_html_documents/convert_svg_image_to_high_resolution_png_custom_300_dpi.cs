// Convert an SVG image to a high‑resolution PNG file with a custom 300 DPI setting.

using System;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string inputPath = "input.svg";
            // Path for the resulting PNG file
            string outputPath = "output.png";

            // Load the SVG document
            SVGDocument document = new SVGDocument(inputPath);

            // Configure image save options with 300 DPI and antialiasing
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to PNG with the specified options
            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}