// Perform parallel EPUB to GIF conversions with a degree of parallelism limit to avoid overwhelming system resources.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample EPUB files (empty placeholders for demonstration)
            string[] inputFiles = new string[] { "sample1.epub", "sample2.epub", "sample3.epub" };
            foreach (string file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]);
                }
            }

            // Set degree of parallelism
            ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                try
                {
                    using (FileStream epubStream = File.OpenRead(inputPath))
                    {
                        ImageSaveOptions saveOptions = new ImageSaveOptions(ImageFormat.Gif);
                        saveOptions.UseAntialiasing = true;
                        saveOptions.HorizontalResolution = 96;
                        saveOptions.VerticalResolution = 96;

                        string outputPath = Path.ChangeExtension(inputPath, ".gif");
                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, saveOptions, outputPath);
                        Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting '{inputPath}': {ex.Message}");
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine($"Fatal error: {e.Message}");
        }
    }
}