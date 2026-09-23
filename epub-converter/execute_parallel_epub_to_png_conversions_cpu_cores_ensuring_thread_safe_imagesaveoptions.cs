// Execute parallel EPUB to PNG conversions across CPU cores, ensuring thread‑safe ImageSaveOptions usage for each task.

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
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Prepare sample EPUB files
            List<string> epubFiles = new List<string>();
            for (int i = 1; i <= 3; i++)
            {
                string epubPath = Path.Combine(dataDir, $"sample{i}.epub");
                if (!File.Exists(epubPath))
                {
                    // Create a placeholder EPUB file
                    File.WriteAllBytes(epubPath, new byte[0]);
                }
                epubFiles.Add(epubPath);
            }

            // Parallel conversion of EPUB to PNG
            Parallel.ForEach(epubFiles, epubPath =>
            {
                using (FileStream stream = File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions();
                    string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(epubPath) + ".png");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            });

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}