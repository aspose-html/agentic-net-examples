// Convert EPUB to GIF while recording overall conversion statistics and outputting them to the console for monitoring.

using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Input EPUB file path
            string inputPath = "input.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Measure conversion time
            Stopwatch sw = Stopwatch.StartNew();

            // Open EPUB file stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF format
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                // Perform conversion
                Converter.ConvertEPUB(stream, options, outputPath);
            }

            sw.Stop();

            // Gather statistics
            long inputSize = new FileInfo(inputPath).Length;
            long outputSize = new FileInfo(outputPath).Length;
            double seconds = sw.Elapsed.TotalSeconds;

            // Output statistics to console
            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Input file size: {inputSize} bytes");
            Console.WriteLine($"Output file size: {outputSize} bytes");
            Console.WriteLine($"Time taken: {seconds:F2} seconds");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during conversion: {ex.Message}");
        }
    }
}