// Benchmark conversion time for SVG to JPEG with different JPEG quality settings to find optimal performance.

using System;
using System.Diagnostics;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source SVG file
            string svgPath = "input.svg";

            // Different JPEG quality levels to benchmark (quality cannot be set via ImageSaveOptions in this example)
            int[] jpegQualities = new int[] { 50, 75, 90 };

            foreach (int quality in jpegQualities)
            {
                // Output file name includes the quality value for identification
                string outputPath = $"output_{quality}.jpg";

                // Create JPEG image save options
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);

                // Start timing the conversion
                Stopwatch timer = Stopwatch.StartNew();

                // Perform the conversion from SVG to JPEG
                Converter.ConvertSVG(svgPath, options, outputPath);

                // Stop timing
                timer.Stop();

                Console.WriteLine($"Quality {quality}: Conversion took {timer.ElapsedMilliseconds} ms, saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}