// Convert SVG files with Unicode characters in filenames to BMP, ensuring correct handling of file paths.

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
            // Define input and output file paths with Unicode characters
            string sourcePath = "图像.svg";
            string outputPath = "图像.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'>
  <rect width='100' height='100' fill='red' />
</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Set image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG file '{sourcePath}' successfully converted to BMP '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}