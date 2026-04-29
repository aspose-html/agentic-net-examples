// Log each successful SVG to BMP conversion with source and destination file paths for audit purposes.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define the SVG source file path
            string sourcePath = "example.svg";

            // Define the BMP output file path
            string outputPath = "example.bmp";

            // Configure image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Perform the conversion from SVG to BMP
            Converter.ConvertSVG(sourcePath, options, outputPath);

            // Log the successful conversion with full paths
            Console.WriteLine($"Conversion succeeded: Source = {Path.GetFullPath(sourcePath)}, Destination = {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            // Log any errors that occur during conversion
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}