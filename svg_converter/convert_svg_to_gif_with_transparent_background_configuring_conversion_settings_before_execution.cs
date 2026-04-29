// Convert SVG to GIF with transparent background by configuring the conversion settings before execution.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string outputPath = "output.gif";

            SVGDocument document = new SVGDocument(svgPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.Transparent;

            Converter.ConvertSVG(document, options, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}