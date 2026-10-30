// Batch transform EPUB documents into GIF animations by iterating over source files and calling Converter.ConvertEPUB.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "OutputGifs");

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            string[] epubFiles = Directory.GetFiles(inputDirectory, "*.epub", SearchOption.TopDirectoryOnly);

            foreach (string epubPath in epubFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                using (FileStream epubStream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                }

                Console.WriteLine($"Converted '{epubPath}' to GIF at '{outputPath}'.");
            }

            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}