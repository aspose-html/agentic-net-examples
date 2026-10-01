// Validate that the output BMP file size is greater than zero after conversion to ensure successful rendering.

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
            // Define input SVG and output BMP paths
            string inputSvgPath = "sample.svg";
            string outputBmpPath = "output.bmp";

            // Create a minimal SVG file
            string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
            File.WriteAllText(inputSvgPath, svgContent);

            // Set up BMP save options
            ImageSaveOptions bmpOptions = new ImageSaveOptions(ImageFormat.Bmp);
            // Optional: enable antialiasing
            bmpOptions.UseAntialiasing = true;

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(inputSvgPath, bmpOptions, outputBmpPath);

            // Validate that the BMP file size is greater than zero
            long fileSize = new FileInfo(outputBmpPath).Length;
            if (fileSize > 0)
            {
                Console.WriteLine($"BMP conversion successful. File size: {fileSize} bytes.");
            }
            else
            {
                Console.WriteLine("BMP conversion failed. Output file size is zero.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}