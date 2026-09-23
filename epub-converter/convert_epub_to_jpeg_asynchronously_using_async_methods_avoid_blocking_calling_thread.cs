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
            string inputPath = "sample.epub";
            string outputPath = "output.jpg";

            await ConvertEpubToJpegAsync(inputPath, outputPath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task ConvertEpubToJpegAsync(string epubPath, string outputPath)
    {
        await Task.Run(() =>
        {
            using (FileStream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }
        });
    }
}