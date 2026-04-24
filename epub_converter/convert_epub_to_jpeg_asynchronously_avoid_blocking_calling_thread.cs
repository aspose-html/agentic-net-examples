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
            // Path to the source EPUB file
            string epubPath = "sample.epub";
            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            await ConvertEpubToJpegAsync(epubPath, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Asynchronous wrapper for the synchronous ConvertEPUB method
    private static Task ConvertEpubToJpegAsync(string epubFilePath, string jpegOutputPath)
    {
        return Task.Run(() =>
        {
            // Open the EPUB file as a readable stream
            using (FileStream stream = File.OpenRead(epubFilePath))
            {
                // Configure image saving options for JPEG format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                // Perform the conversion
                Converter.ConvertEPUB(stream, options, jpegOutputPath);
            }
        });
    }
}