// Render an SVG file to PNG with transparent background and custom DPI for UI icons.

using System;
using System.IO;
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
            // Define input and output paths
            string inputPath = "icon.svg";
            string outputPath = "icon.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='64' height='64'>
    <circle cx='32' cy='32' r='30' fill='red' />
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Load the SVG document
            using (SVGDocument document = new SVGDocument(inputPath))
            {
                // Configure image save options
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 96; // custom DPI
                options.VerticalResolution = 96;   // custom DPI
                options.BackgroundColor = Color.Transparent;
                options.UseAntialiasing = true;

                // Convert SVG to PNG with transparent background
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine($"SVG has been successfully rendered to PNG: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}