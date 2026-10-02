// Convert an SVG file to BMP format by selecting BMP as the target in the conversion API.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.svg";
            string outputPath = "output.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG file has been successfully converted to BMP: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}