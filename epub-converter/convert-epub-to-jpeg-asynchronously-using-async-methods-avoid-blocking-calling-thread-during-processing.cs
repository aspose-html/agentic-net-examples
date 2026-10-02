// Convert EPUB to JPEG asynchronously using async methods to avoid blocking the calling thread during processing.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            // Define input EPUB file and output directory
            string dataDir = "Data";
            string inputFileName = "sample.epub";
            string inputPath = System.IO.Path.Combine(dataDir, inputFileName);
            string outputDir = "Output";

            // Ensure the output directory exists
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a file stream for the EPUB file
            using (FileStream epubStream = System.IO.File.OpenRead(inputPath))
            {
                // Set image save options to JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Perform conversion asynchronously to avoid blocking the calling thread
                await Task.Run(() => Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputDir));
            }

            Console.WriteLine("EPUB conversion to JPEG completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during EPUB to JPEG conversion: {ex.Message}");
        }
    }
}