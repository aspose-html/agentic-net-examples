// Convert an SVG file to BMP format by selecting BMP as the target in the conversion API.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace SvgToBmp
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source SVG file
                string sourcePath = "input.svg";

                // Configure image save options for BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Path for the output BMP file
                string outputPath = "output.bmp";

                // Perform conversion
                Converter.ConvertSVG(sourcePath, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}