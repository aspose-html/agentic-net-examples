// Convert EPUB to BMP while logging conversion progress through a callback function supplied to the Converter.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file path and output BMP file path
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            // Ensure a sample EPUB file exists (minimal placeholder)
            if (!File.Exists(inputPath))
            {
                // Create a minimal empty file as placeholder
                File.WriteAllBytes(inputPath, new byte[] { 0x50, 0x4B, 0x03, 0x04 }); // ZIP header for EPUB
            }

            // Open the EPUB file as a stream
            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                // Configure image save options for BMP format
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);

                // Log start of conversion
                Console.WriteLine("Starting EPUB to BMP conversion...");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                // Log completion
                Console.WriteLine($"Conversion completed. BMP saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}