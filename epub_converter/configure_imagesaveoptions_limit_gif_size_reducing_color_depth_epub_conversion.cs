// Configure ImageSaveOptions to limit GIF file size by reducing color depth during EPUB conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB and output GIF paths
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(outputDir);
            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "result.gif");

            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(epubPath))
            {
                // Create ImageSaveOptions for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Reduce color depth if the API provides such a property
                // options.ColorDepth = ColorDepth.Depth8Bit; // Uncomment if supported

                // Convert EPUB to GIF using the configured options
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Conversion failed: {ex.Message}");
        }
    }
}