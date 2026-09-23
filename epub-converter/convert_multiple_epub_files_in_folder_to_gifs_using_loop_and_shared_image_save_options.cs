// Convert multiple EPUB files in a folder to GIFs using a loop and shared ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputGifs");

            if (!Directory.Exists(inputDir))
                Directory.CreateDirectory(inputDir);
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Shared ImageSaveOptions for GIF conversion
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");
            foreach (string epubPath in epubFiles)
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".gif";
                    string outputPath = Path.Combine(outputDir, outputFileName);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}