// Convert EPUB to PNG and implement IProgress interface to receive real‑time updates from the conversion process.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare input EPUB file (create a dummy file if it does not exist)
            string inputPath = "sample.epub";
            if (!File.Exists(inputPath))
            {
                File.WriteAllBytes(inputPath, new byte[0]);
            }

            // Define output PNG file path
            string outputPath = "output.png";

            // Create image save options
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            // Implement IProgress to receive conversion updates
            ProgressReporter progress = new ProgressReporter();

            // Report start
            progress.Report(0);
            Console.WriteLine("Conversion started...");

            // Perform EPUB to PNG conversion
            using (FileStream epubStream = File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(epubStream, options, outputPath);
            }

            // Report completion
            progress.Report(100);
            Console.WriteLine($"Conversion completed. PNG saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple IProgress implementation
    class ProgressReporter : IProgress<int>
    {
        public void Report(int value)
        {
            Console.WriteLine($"Progress: {value}%");
        }
    }
}