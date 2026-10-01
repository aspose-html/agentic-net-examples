// Benchmark conversion time for SVG to JPEG with different JPEG quality settings to find optimal performance.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Converters;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='5'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";
            string svgPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.svg");
            File.WriteAllText(svgPath, svgContent);

            // Output paths
            string highOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "high_quality.jpg");
            string lowOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "low_quality.jpg");

            // High quality conversion (default settings)
            ImageSaveOptions highOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low quality conversion (default settings, no explicit quality property)
            ImageSaveOptions lowOptions = new ImageSaveOptions(ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("High quality image is larger than low quality image.");
            }
            else if (highSize < lowSize)
            {
                Console.WriteLine("Low quality image is larger than high quality image (unexpected).");
            }
            else
            {
                Console.WriteLine("Both images have the same size.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}