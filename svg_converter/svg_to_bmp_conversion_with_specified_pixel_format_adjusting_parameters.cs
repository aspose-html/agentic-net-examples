// Perform SVG to BMP conversion with a specified pixel format by adjusting the conversion parameters.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace SvgToBmpConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source SVG file
                string sourcePath = "input.svg";

                // Path where the BMP image will be saved
                string outputPath = "output.bmp";

                // Create image save options with BMP format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

                // Convert the SVG to BMP using the specified options
                Converter.ConvertSVG(sourcePath, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}