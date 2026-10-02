// Convert an EPUB file to GIF format through Converter.ConvertEPUB using the library’s default configuration.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Ensure the input file exists (for demonstration purposes, you may need to provide a valid EPUB file)
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            // Create image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Open the EPUB file as a stream and perform conversion
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed successfully. GIF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}