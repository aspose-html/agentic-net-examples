// Create a naming pattern that includes conversion timestamp when saving BMP files from SVG sources.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

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

            // Build output file name with current timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string outputPath = $"output_{timestamp}.bmp";

            // Convert SVG to BMP using Aspose.HTML
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}