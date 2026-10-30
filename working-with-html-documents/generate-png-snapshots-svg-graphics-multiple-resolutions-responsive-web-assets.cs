// Generate PNG snapshots of SVG graphics at multiple resolutions for responsive web assets.

using System;
using System.IO;
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
            // Prepare a sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Define resolutions
            int[] horizontalResolutions = new int[] { 72, 150, 300 };
            int[] verticalResolutions = new int[] { 72, 150, 300 };

            for (int i = 0; i < horizontalResolutions.Length; i++)
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = horizontalResolutions[i];
                options.VerticalResolution = verticalResolutions[i];
                options.BackgroundColor = Color.White;
                options.UseAntialiasing = true;

                string outputPath = $"output_{horizontalResolutions[i]}x{verticalResolutions[i]}.png";

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                Console.WriteLine($"Saved PNG at {horizontalResolutions[i]} DPI to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}