// Run parallel conversions from EPUB to TIFF using Task.Run for each file, handling exceptions individually.

using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            string[] inputFiles = { "sample1.epub", "sample2.epub" };
            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Ensure sample EPUB files exist (dummy content for example purposes)
            foreach (var file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllText(file, "Dummy EPUB content");
                }
            }

            Task[] tasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".tiff");

                tasks[i] = Task.Run(() =>
                {
                    try
                    {
                        using (Stream stream = File.OpenRead(inputPath))
                        {
                            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                            Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{inputPath}': {ex.Message}");
                    }
                });
            }

            Task.WaitAll(tasks);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fatal error: {ex.Message}");
        }
    }
}