// Execute parallel EPUB to PNG conversions across CPU cores, ensuring thread‑safe ImageSaveOptions usage for each task.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Directories for input EPUB files and output PNG images
            string inputDir = "InputEpubs";
            string outputDir = "OutputPngs";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Get all EPUB files in the input directory
            var epubFiles = Directory.GetFiles(inputDir, "*.epub");

            // Process each EPUB file in parallel, utilizing all CPU cores
            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    // Determine output PNG file path (same name as EPUB)
                    string fileName = Path.GetFileNameWithoutExtension(epubPath);
                    string outputPath = Path.Combine(outputDir, fileName + ".png");

                    // Open the EPUB file as a readable stream
                    using (Stream stream = File.OpenRead(epubPath))
                    {
                        // Create a new ImageSaveOptions instance for this thread (thread‑safe)
                        ImageSaveOptions options = new ImageSaveOptions();

                        // Convert the EPUB stream to a PNG image and save to the output path
                        Converter.ConvertEPUB(stream, options, outputPath);
                    }
                }
                catch (Exception ex)
                {
                    // Log any conversion errors for the specific file
                    Console.WriteLine($"Error converting '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception e)
        {
            // Log fatal errors that prevent the overall process from running
            Console.WriteLine($"Fatal error: {e.Message}");
        }
    }
}