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
            var inputFiles = new List<string>
            {
                "sample1.epub",
                "sample2.epub"
            };

            foreach (var file in inputFiles)
            {
                if (!File.Exists(file))
                {
                    File.WriteAllBytes(file, new byte[0]);
                }
            }

            var outputDir = "output";
            Directory.CreateDirectory(outputDir);

            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 4 };

            Parallel.ForEach(inputFiles, parallelOptions, inputPath =>
            {
                var fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                var outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".gif");

                using (var epubStream = File.OpenRead(inputPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                    options.UseAntialiasing = true;
                    options.HorizontalResolution = 96;
                    options.VerticalResolution = 96;

                    Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
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