// Render an SVG file to PNG with transparent background and custom DPI for UI icons.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input SVG and output PNG paths
            string documentPath = "sample.svg";
            string outputPath = "output.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(documentPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red' /></svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            // Load the SVG document
            using (SVGDocument document = new SVGDocument(documentPath))
            {
                // Configure image save options
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 300; // Custom DPI
                options.VerticalResolution = 300;   // Custom DPI
                options.BackgroundColor = Color.Transparent;
                options.UseAntialiasing = true;

                // Convert SVG to PNG
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine($"SVG has been successfully converted to PNG: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}