// Convert multiple EPUB files in a folder to GIFs using a loop and shared ImageSaveOptions.

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

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            foreach (string epubPath in Directory.GetFiles(inputDir, "*.epub"))
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".gif");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}