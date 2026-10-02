// Benchmark conversion time for SVG to JPEG with different JPEG quality settings to find optimal performance.

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
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                File.WriteAllText(svgPath, "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>");
            }

            string highOutputPath = "high_res.jpg";
            string lowOutputPath = "low_res.jpg";

            // High resolution options
            ImageSaveOptions highOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;

            // Low resolution options
            ImageSaveOptions lowOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;

            Stopwatch sw = new Stopwatch();

            // Convert with high resolution
            sw.Start();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);
            sw.Stop();
            long highTime = sw.ElapsedMilliseconds;

            // Convert with low resolution
            sw.Restart();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);
            sw.Stop();
            long lowTime = sw.ElapsedMilliseconds;

            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            Console.WriteLine($"High resolution conversion: {highTime} ms, size: {highSize} bytes");
            Console.WriteLine($"Low resolution conversion: {lowTime} ms, size: {lowSize} bytes");

            if (highTime < lowTime)
                Console.WriteLine("High resolution conversion is faster.");
            else if (lowTime < highTime)
                Console.WriteLine("Low resolution conversion is faster.");
            else
                Console.WriteLine("Both conversions took the same time.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}