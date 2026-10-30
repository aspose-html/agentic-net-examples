// Run parallel conversions from EPUB to TIFF using Task.Run for each file, handling exceptions individually.

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
            // Sample input EPUB files and corresponding output TIFF paths
            var files = new List<(string inputPath, string outputPath)>
            {
                ("sample1.epub", "output1.tiff"),
                ("sample2.epub", "output2.tiff"),
                ("sample3.epub", "output3.tiff")
            };

            // Ensure sample EPUB files exist (create empty placeholders if needed)
            foreach (var (inputPath, _) in files)
            {
                if (!File.Exists(inputPath))
                {
                    // Create a minimal empty EPUB file placeholder
                    using (var fs = File.Create(inputPath))
                    {
                        // No content needed for demonstration purposes
                    }
                }
            }

            var tasks = new List<Task>();

            foreach (var (inputPath, outputPath) in files)
            {
                var task = Task.Run(() =>
                {
                    try
                    {
                        using (Stream stream = File.OpenRead(inputPath))
                        {
                            var options = new ImageSaveOptions(ImageFormat.Tiff);
                            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                            Console.WriteLine($"Successfully converted '{inputPath}' to '{outputPath}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{inputPath}': {ex.Message}");
                    }
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}