// Convert EPUB to JPEG asynchronously using async methods to avoid blocking the calling thread during processing.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Prepare input and output paths
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            string epubPath = Path.Combine(dataDir, "sample.epub");
            string outputPath = Path.Combine(outputDir, "page.jpg");

            // Ensure a placeholder EPUB file exists (for demonstration purposes)
            if (!File.Exists(epubPath))
            {
                // Create an empty file; in a real scenario, provide a valid EPUB file.
                File.WriteAllBytes(epubPath, new byte[0]);
            }

            // Configure image save options for JPEG format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

            // Perform conversion asynchronously to avoid blocking the calling thread
            await Task.Run(() =>
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            });

            Console.WriteLine($"EPUB has been converted to JPEG and saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}