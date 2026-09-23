// Parallelize conversion of multiple EPUB files to JPEG using Parallel.ForEach to improve processing throughput.

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
            string inputDir = Path.Combine(Directory.GetCurrentDirectory(), "InputEpubs");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "OutputJpegs");

            Directory.CreateDirectory(inputDir);
            Directory.CreateDirectory(outputDir);

            // Create sample EPUB files (empty placeholders for demonstration)
            for (int i = 1; i <= 3; i++)
            {
                string samplePath = Path.Combine(inputDir, $"sample{i}.epub");
                if (!File.Exists(samplePath))
                {
                    File.WriteAllBytes(samplePath, new byte[0]);
                }
            }

            string[] epubFiles = Directory.GetFiles(inputDir, "*.epub");

            Parallel.ForEach(epubFiles, epubPath =>
            {
                try
                {
                    using (FileStream epubStream = File.OpenRead(epubPath))
                    {
                        Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                        string outputFileName = Path.GetFileNameWithoutExtension(epubPath) + ".jpg";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                        Console.WriteLine($"Converted '{epubPath}' to '{outputPath}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error converting '{epubPath}': {ex.Message}");
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}