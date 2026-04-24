// Load SVG content from a file and convert it to JPEG image using ImageDevice with quality parameter.

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
            string outputPath = "output.jpg";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            Converter.ConvertSVG(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}