// Convert a single SVG file to BMP using the one‑line Converter.ConvertSVG method.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.svg";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            string outputPath = "output.bmp";
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}