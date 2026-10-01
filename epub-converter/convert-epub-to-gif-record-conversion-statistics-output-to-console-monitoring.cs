// Convert EPUB to GIF while recording overall conversion statistics and outputting them to the console for monitoring.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input EPUB file path (replace with actual file if needed)
            string inputPath = "sample.epub";
            // Output GIF file path
            string outputPath = "output.gif";

            // Ensure input file exists (optional: create a placeholder file)
            if (!File.Exists(inputPath))
            {
                // Create an empty placeholder EPUB file (for demonstration purposes)
                using (FileStream placeholder = File.Create(inputPath))
                {
                    // No content; real conversion will require a valid EPUB.
                }
            }

            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Configure image save options for GIF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Measure conversion time
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                stopwatch.Stop();

                // Get output file size
                long outputSize = new FileInfo(outputPath).Length;

                // Output statistics
                Console.WriteLine("EPUB to GIF conversion completed.");
                Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine($"Output GIF size: {outputSize} bytes");
                Console.WriteLine($"Output file: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}