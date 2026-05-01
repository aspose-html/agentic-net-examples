// Render an SVG file to PNG with transparent background and custom DPI for UI icons.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            string outputPath = "output.png";

            SVGDocument document = new SVGDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.Transparent;
            options.UseAntialiasing = true;

            Converter.ConvertSVG(document, options, outputPath);
            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}