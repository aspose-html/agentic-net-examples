// Create a scheduled task that periodically converts newly added EPUB files in a directory to GIFs.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputDirectory = "InputEpubs";
            string outputDirectory = "OutputGifs";

            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            foreach (string epubFilePath in Directory.GetFiles(inputDirectory, "*.epub"))
            {
                using (FileStream stream = File.OpenRead(epubFilePath))
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubFilePath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    var options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Gif);

                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                    Console.WriteLine($"Converted '{epubFilePath}' to '{outputPath}'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}