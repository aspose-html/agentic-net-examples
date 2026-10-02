// Create a batch processing method that accepts a list of EPUB paths and outputs corresponding GIF files.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            var epubFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            ConvertEpubBatch(epubFiles, outputDir);
            Console.WriteLine("Batch conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertEpubBatch(IEnumerable<string> epubPaths, string outputDirectory)
    {
        foreach (var epubPath in epubPaths)
        {
            try
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".gif";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to convert '{epubPath}': {ex.Message}");
            }
        }
    }
}