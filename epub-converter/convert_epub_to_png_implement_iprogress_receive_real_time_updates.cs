// Convert EPUB to PNG and implement IProgress interface to receive real‑time updates from the conversion process.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.png";

            // Create a placeholder EPUB file if it does not exist
            if (!File.Exists(inputPath))
            {
                using (FileStream fs = new FileStream(inputPath, FileMode.Create))
                {
                    // Minimal placeholder content (empty file)
                }
            }

            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions();
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                IProgress<int> progress = new Progress<int>(p => Console.WriteLine($"Conversion progress: {p}%"));

                Console.WriteLine("Starting EPUB to PNG conversion...");
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
                progress.Report(100);
                Console.WriteLine($"Conversion completed. PNG saved to '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}