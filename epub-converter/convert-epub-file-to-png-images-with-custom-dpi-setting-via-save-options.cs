// Convert an EPUB file to PNG images with a custom DPI setting via appropriate save options.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file and output PNG path
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "page.png");

            // Ensure the EPUB file exists (placeholder for the example)
            if (!File.Exists(epubPath))
            {
                Console.WriteLine($"EPUB file not found at '{epubPath}'. Please place a valid .epub file there.");
                return;
            }

            // Open the EPUB file stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Configure image save options with custom DPI
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300; // DPI horizontally
                options.VerticalResolution = 300;   // DPI vertically

                // Convert EPUB to PNG images
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine($"Conversion completed. PNG files are saved to '{outputDir}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}