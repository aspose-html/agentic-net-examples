// Convert EPUB to BMP while recording source file path, output location, and options used into a log.

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
            // Define input EPUB file and output BMP file paths
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Log the conversion parameters
            Console.WriteLine("Starting EPUB to BMP conversion");
            Console.WriteLine($"Source file: {inputPath}");
            Console.WriteLine($"Destination file: {outputPath}");
            Console.WriteLine("Conversion options: Image format = Bmp");

            // Create image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Open the EPUB file as a read-only stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}