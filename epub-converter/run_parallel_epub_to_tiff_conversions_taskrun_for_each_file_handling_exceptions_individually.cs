// Run parallel conversions from EPUB to TIFF using Task.Run for each file, handling exceptions individually.

using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            var epubFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub",
                "sample3.epub"
            };

            var tasks = new List<Task>();

            foreach (var epubPath in epubFiles)
            {
                tasks.Add(Task.Run(() =>
                {
                    try
                    {
                        if (!File.Exists(epubPath))
                        {
                            File.WriteAllBytes(epubPath, new byte[0]);
                        }

                        using (var stream = File.OpenRead(epubPath))
                        {
                            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                            string outputPath = Path.ChangeExtension(epubPath, ".tiff");
                            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                            Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{epubPath}': {ex.Message}");
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}