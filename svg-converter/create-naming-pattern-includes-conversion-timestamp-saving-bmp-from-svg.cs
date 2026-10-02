// Create a naming pattern that includes conversion timestamp when saving BMP files from SVG sources.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg width=\"200\" height=\"200\" xmlns=\"http://www.w3.org/2000/svg\"><rect width=\"200\" height=\"200\" fill=\"orange\"/></svg>";

            // Create BMP save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Build output file name with timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputFileName = $"svg_to_bmp_{timestamp}.bmp";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Convert SVG string to BMP file
            Aspose.Html.Converters.Converter.ConvertSVG(svgContent, ".", options, outputPath);

            Console.WriteLine($"SVG has been converted to BMP successfully: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}