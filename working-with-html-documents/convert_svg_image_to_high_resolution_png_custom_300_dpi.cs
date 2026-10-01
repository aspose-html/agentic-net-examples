// Convert an SVG image to a high‑resolution PNG file with a custom 300 DPI setting.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG path and output image path
            string svgPath = "sample.svg";
            string outputPath = "output.jpeg";

            // Ensure a minimal SVG file exists
            if (!File.Exists(svgPath))
            {
                string minimalSvg = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
                                        <rect width='200' height='200' fill='lightblue'/>
                                        <circle cx='100' cy='100' r='80' fill='orange'/>
                                      </svg>";
                File.WriteAllText(svgPath, minimalSvg);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to image
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to image: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}