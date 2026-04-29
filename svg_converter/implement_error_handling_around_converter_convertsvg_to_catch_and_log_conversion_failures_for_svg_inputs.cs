// Implement error handling around Converter.ConvertSVG to catch and log conversion failures for SVG inputs.

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
            string sourcePath = "input.svg";
            string outputPath = "output.jpeg";
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Converter.ConvertSVG(sourcePath, options, outputPath);
            Console.WriteLine("Conversion succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}