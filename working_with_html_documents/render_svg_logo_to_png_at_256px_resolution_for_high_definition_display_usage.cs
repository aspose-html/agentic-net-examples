// Render an SVG logo to PNG at 256 px resolution for high‑definition display usage.

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
            string sourcePath = "logo.svg";
            // Path for the resulting PNG file
            string outputPath = "logo.png";

            // Load the SVG document
            SVGDocument document = new SVGDocument(sourcePath);

            // Configure image saving options
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 256; // DPI horizontal
            options.VerticalResolution = 256;   // DPI vertical
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to PNG with the specified options
            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}