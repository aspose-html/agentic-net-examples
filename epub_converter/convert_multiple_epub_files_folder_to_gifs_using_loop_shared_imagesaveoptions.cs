// Convert multiple EPUB files in a folder to GIFs using a loop and shared ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output directories
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputGifs");
            Directory.CreateDirectory(outputDir);

            // Create shared ImageSaveOptions for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Loop through all EPUB files in the input folder
            foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
            {
                // Open the EPUB file as a readable stream
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    // Build the output GIF file path
                    string outputFileName = Path.ChangeExtension(Path.GetFileName(epubPath), ".gif");
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Convert the EPUB to GIF using Aspose.Html
                    Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}