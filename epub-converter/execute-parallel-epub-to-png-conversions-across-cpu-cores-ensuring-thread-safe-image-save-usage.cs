// Execute parallel EPUB to PNG conversions across CPU cores, ensuring thread‑safe ImageSaveOptions usage for each task.

using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string outputDir = "Output";
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            var epubFiles = new List<string>
            {
                Path.Combine(dataDir, "sample1.epub"),
                Path.Combine(dataDir, "sample2.epub")
            };

            foreach (var file in epubFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]);
                }
            }

            Parallel.ForEach(epubFiles, epubPath =>
            {
                var options = new ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                string outputPath = Path.Combine(outputDir,
                    Path.GetFileNameWithoutExtension(epubPath) + ".png");

                using (var stream = File.OpenRead(epubPath))
                {
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            });

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}