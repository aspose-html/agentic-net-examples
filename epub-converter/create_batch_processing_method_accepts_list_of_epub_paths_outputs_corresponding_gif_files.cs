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
            // Sample EPUB file paths (created as empty files for demonstration)
            var epubPaths = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            // Create minimal sample EPUB files (empty content)
            foreach (var path in epubPaths)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllBytes(path, new byte[0]);
                }
            }

            string outputDirectory = "output_gifs";
            ConvertEpubBatch(epubPaths, outputDirectory);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static void ConvertEpubBatch(List<string> epubPaths, string outputDirectory)
    {
        if (!Directory.Exists(outputDirectory))
        {
            Directory.CreateDirectory(outputDirectory);
        }

        foreach (var epubPath in epubPaths)
        {
            try
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".gif";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    var options = new Aspose.Html.Saving.ImageSaveOptions(
                        Aspose.Html.Rendering.Image.ImageFormat.Gif);

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