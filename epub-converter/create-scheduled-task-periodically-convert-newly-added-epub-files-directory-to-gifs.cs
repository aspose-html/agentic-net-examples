// Create a scheduled task that periodically converts newly added EPUB files in a directory to GIFs.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "InputEpubs";
            string outputDir = "OutputGifs";

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");

            foreach (string epubPath in epubFiles)
            {
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".gif");

                using (FileStream stream = File.OpenRead(epubPath))
                {
                    ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }

                Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}