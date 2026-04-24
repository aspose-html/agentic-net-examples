// Run parallel conversions from EPUB to TIFF using Task.Run for each file, handling exceptions individually.

using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string[] epubFiles = { "book1.epub", "book2.epub", "book3.epub" };
            Task[] tasks = new Task[epubFiles.Length];
            for (int i = 0; i < epubFiles.Length; i++)
            {
                string inputPath = epubFiles[i];
                string outputPath = Path.ChangeExtension(inputPath, ".tiff");
                tasks[i] = Task.Run(() =>
                {
                    try
                    {
                        using (FileStream stream = File.OpenRead(inputPath))
                        {
                            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                            Converter.ConvertEPUB(stream, options, outputPath);
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