// Render an SVG diagram to PNG with anti‑aliasing enabled and custom DPI for clarity.

using System;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace SvgToPngExample
{
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
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.White;
                options.UseAntialiasing = true;

                Converter.ConvertSVG(document, options, outputPath);
                Console.WriteLine("SVG has been successfully converted to PNG.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}