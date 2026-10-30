// Convert EPUB to GIF while recording overall conversion statistics and outputting them to the console for monitoring.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path (sample)
            string inputPath = "sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Ensure the input file exists (create a minimal placeholder if missing)
            if (!System.IO.File.Exists(inputPath))
            {
                // Create an empty file as placeholder (real EPUB content required for actual conversion)
                using (var placeholder = System.IO.File.Create(inputPath))
                {
                    // No content written
                }
            }

            // Prepare conversion options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            // Record start time
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            // Perform conversion
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            // Stop timer
            stopwatch.Stop();

            // Gather statistics
            long inputSize = new System.IO.FileInfo(inputPath).Length;
            long outputSize = new System.IO.FileInfo(outputPath).Length;
            double durationSeconds = stopwatch.Elapsed.TotalSeconds;

            // Output statistics
            Console.WriteLine("EPUB to GIF conversion completed.");
            Console.WriteLine($"Input file:  {inputPath} ({inputSize} bytes)");
            Console.WriteLine($"Output file: {outputPath} ({outputSize} bytes)");
            Console.WriteLine($"Conversion time: {durationSeconds:F2} seconds");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}