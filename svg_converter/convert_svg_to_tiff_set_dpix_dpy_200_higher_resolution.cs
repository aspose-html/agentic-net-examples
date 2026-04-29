// Convert an SVG to TIFF and set ImageSaveOptions.DpiX and DpiY to 200 for higher resolution.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace SvgToTiffExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "input.svg";
                string outputPath = "output.tiff";

                SVGDocument document = new SVGDocument(sourcePath);
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.Compression = Compression.None;
                options.HorizontalResolution = 200;
                options.VerticalResolution = 200;

                Converter.ConvertSVG(document, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}