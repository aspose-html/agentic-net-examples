// Apply a custom DPI of 250 when rendering SVG to PNG for high‑resolution UI components.

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
            string sourcePath = "input.svg";

            // Path where the PNG will be saved
            string outputPath = "output.png";

            // Load the SVG document
            SVGDocument document = new SVGDocument(sourcePath);

            // Configure image saving options with custom DPI and rendering settings
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 250; // DPI horizontally
            options.VerticalResolution = 250;   // DPI vertically
            options.BackgroundColor = Color.White; // Canvas background color
            options.UseAntialiasing = true;    // Enable antialiasing for smoother graphics

            // Convert SVG to PNG using the configured options
            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}