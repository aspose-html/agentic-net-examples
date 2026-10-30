// Convert EPUB to PNG and define a transparent background using ImageSaveOptions.BackgroundColor set to transparent.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (placeholder)
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            if (!File.Exists(epubPath))
            {
                // Create an empty file as a placeholder; replace with a real EPUB for actual conversion
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Prepare output directory
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string outputPath = Path.Combine(outputDir, "output.png");

            // Open EPUB stream
            using (Stream stream = File.OpenRead(epubPath))
            {
                // Configure image save options with transparent background
                ImageSaveOptions options = new ImageSaveOptions();
                options.BackgroundColor = Color.Transparent;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}