// Convert a DRM‑free EPUB to PNG while handling potential encryption exceptions during the conversion process.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB file path
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");

            // Define output PNG file path
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.png");

            // Ensure the input file exists (for demonstration purposes, create an empty file if missing)
            if (!File.Exists(epubPath))
            {
                // In a real scenario, place a valid DRM‑free EPUB at the specified location.
                File.WriteAllBytes(epubPath, new byte[0]);
                Console.WriteLine("Created placeholder EPUB file at: " + epubPath);
            }

            using (FileStream epubStream = File.OpenRead(epubPath))
            {
                // Configure image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            // Handle potential encryption or other conversion exceptions
            Console.WriteLine("Error during EPUB to PNG conversion: " + ex.Message);
        }
    }
}