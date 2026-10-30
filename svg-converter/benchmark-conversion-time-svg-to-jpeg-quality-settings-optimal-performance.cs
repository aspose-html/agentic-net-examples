// Benchmark conversion time for SVG to JPEG with different JPEG quality settings to find optimal performance.

using System;
using System.IO;
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
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"red\"/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Output paths
            string lowOutputPath = "low_res.jpg";
            string highOutputPath = "high_res.jpg";

            // Low resolution options
            ImageSaveOptions lowOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            lowOptions.HorizontalResolution = 72;
            lowOptions.VerticalResolution = 72;

            // High resolution options
            ImageSaveOptions highOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            highOptions.HorizontalResolution = 300;
            highOptions.VerticalResolution = 300;

            // Benchmark low resolution conversion
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);
            sw.Stop();
            long lowTime = sw.ElapsedMilliseconds;

            // Benchmark high resolution conversion
            sw.Reset();
            sw.Start();
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);
            sw.Stop();
            long highTime = sw.ElapsedMilliseconds;

            // File sizes
            long lowSize = new FileInfo(lowOutputPath).Length;
            long highSize = new FileInfo(highOutputPath).Length;

            // Output results
            Console.WriteLine($"Low resolution conversion time: {lowTime} ms, size: {lowSize} bytes");
            Console.WriteLine($"High resolution conversion time: {highTime} ms, size: {highSize} bytes");

            if (highTime < lowTime)
            {
                Console.WriteLine("High resolution conversion was faster.");
            }
            else if (highTime > lowTime)
            {
                Console.WriteLine("Low resolution conversion was faster.");
            }
            else
            {
                Console.WriteLine("Both conversions took the same time.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}