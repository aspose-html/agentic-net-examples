// Apply a custom DPI of 250 when rendering SVG to PNG for high‑resolution UI components.

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
            string inputPath = "sample.svg";
            string outputPath = "output.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(inputPath);

            // Configure image save options with custom DPI
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 250;
            options.VerticalResolution = 250;
            options.UseAntialiasing = true;
            options.BackgroundColor = Color.White;

            // Convert SVG to PNG
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("SVG has been successfully rendered to PNG with 250 DPI.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}