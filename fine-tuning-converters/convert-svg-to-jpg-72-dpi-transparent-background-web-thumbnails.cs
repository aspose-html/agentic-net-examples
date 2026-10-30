// Convert an SVG file to JPG with 72 DPI resolution and transparent background for web thumbnails.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path
            string svgPath = "sample.svg";
            // Output JPEG file path
            string outputPath = "thumbnail.jpg";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='red' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            options.BackgroundColor = System.Drawing.Color.Transparent;

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to JPEG at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}