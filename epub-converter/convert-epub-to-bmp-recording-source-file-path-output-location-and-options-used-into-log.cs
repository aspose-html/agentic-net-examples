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

            // Ensure a minimal sample EPUB file exists
            if (!File.Exists(inputPath))
            {
                // Write a simple ZIP header to make it a valid zip container (EPUB is a zip archive)
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 });
            }

            // Create image save options for BMP format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);

            // Open the EPUB file as a read-only stream
            using (Stream stream = File.OpenRead(inputPath))
            {
                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Log conversion details
            Console.WriteLine("EPUB to BMP conversion completed.");
            Console.WriteLine($"Source file: {Path.GetFullPath(inputPath)}");
            Console.WriteLine($"Output file: {Path.GetFullPath(outputPath)}");
            Console.WriteLine($"Options used: Format = {options.Format}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}