// Generate PNG snapshots of SVG graphics at multiple resolutions for responsive web assets.

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
            string svgPath = "input.svg";
            string outputFolder = "output";

            SVGDocument document = new SVGDocument(svgPath);

            int[] dpis = { 72, 150, 300 };
            foreach (int dpi in dpis)
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = dpi;
                options.VerticalResolution = dpi;
                options.BackgroundColor = Color.White;
                options.UseAntialiasing = true;

                string outputPath = System.IO.Path.Combine(outputFolder, $"output_{dpi}dpi.png");
                Converter.ConvertSVG(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}