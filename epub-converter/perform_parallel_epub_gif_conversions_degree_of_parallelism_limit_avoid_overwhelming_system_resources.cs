// Perform parallel EPUB to GIF conversions with a degree of parallelism limit to avoid overwhelming system resources.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // Define input EPUB files (for demo purposes, create dummy files if they don't exist)
            string inputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "OutputGifs");
            Directory.CreateDirectory(inputDirectory);
            Directory.CreateDirectory(outputDirectory);

            // Sample file names
            List<string> epubFiles = new List<string>
            {
                Path.Combine(inputDirectory, "sample1.epub"),
                Path.Combine(inputDirectory, "sample2.epub"),
                Path.Combine(inputDirectory, "sample3.epub")
            };

            // Ensure dummy EPUB files exist
            foreach (var file in epubFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]); // empty placeholder
                }
            }

            // Set degree of parallelism
            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(epubFiles, parallelOptions, epubPath =>
            {
                try
                {
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(epubPath);
                    string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".gif");

                    using (FileStream epubStream = File.OpenRead(epubPath))
                    {
                        var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                        options.UseAntialiasing = true;
                        options.HorizontalResolution = 96;
                        options.VerticalResolution = 96;

                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                    }

                    Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}