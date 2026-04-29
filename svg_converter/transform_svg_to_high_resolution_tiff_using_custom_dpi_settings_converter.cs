// Transform an SVG file into a high‑resolution TIFF image using custom DPI settings in the converter.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

namespace SvgToTiffConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source SVG file
                string sourcePath = "input.svg";

                // Path where the resulting TIFF will be saved
                string outputPath = "output.tiff";

                // Desired DPI for the output image
                int dpi = 300;

                // Load the SVG document
                SVGDocument document = new SVGDocument(sourcePath);

                // Configure image save options for TIFF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.Compression = Compression.None;
                options.HorizontalResolution = dpi;
                options.VerticalResolution = dpi;

                // Perform the conversion
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