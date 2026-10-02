// Benchmark conversion time for MHTML to GIF using different ImageSaveOptions quality levels.

using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample MHTML file
            string inputPath = "sample.mht";
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Sample MHTML</h1><p>This is a test.</p></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Output paths
            string outputLow = "output_low.gif";
            string outputHigh = "output_high.gif";

            // Benchmark with low resolution
            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions optionsLow = new ImageSaveOptions(ImageFormat.Gif);
                optionsLow.HorizontalResolution = 96;
                optionsLow.VerticalResolution = 96;

                Stopwatch sw = Stopwatch.StartNew();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, optionsLow, outputLow);
                sw.Stop();

                Console.WriteLine($"Low resolution conversion time: {sw.ElapsedMilliseconds} ms");
            }

            // Benchmark with high resolution
            using (Stream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions optionsHigh = new ImageSaveOptions(ImageFormat.Gif);
                optionsHigh.HorizontalResolution = 300;
                optionsHigh.VerticalResolution = 300;

                Stopwatch sw = Stopwatch.StartNew();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, optionsHigh, outputHigh);
                sw.Stop();

                Console.WriteLine($"High resolution conversion time: {sw.ElapsedMilliseconds} ms");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}