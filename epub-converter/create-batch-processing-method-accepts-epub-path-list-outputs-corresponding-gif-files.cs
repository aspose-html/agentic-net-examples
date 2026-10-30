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
            // Sample input EPUB files (created as empty placeholders if they do not exist)
            var epubFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            foreach (var file in epubFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]);
                }
            }

            // Output directory for GIF files
            string outputDir = "output_gifs";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            ProcessEpubBatch(epubFiles, outputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcessEpubBatch(List<string> epubPaths, string outputDirectory)
    {
        foreach (var epubPath in epubPaths)
        {
            try
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    string outputFileName = System.IO.Path.GetFileNameWithoutExtension(epubPath) + ".gif";
                    string outputPath = System.IO.Path.Combine(outputDirectory, outputFileName);

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