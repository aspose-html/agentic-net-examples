// Create a PowerShell function that wraps the .NET Converter API for SVG to JPEG conversion with quality parameter.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string svgPath = "sample.svg";
            string highOutputPath = "high_quality.jpg";
            string lowOutputPath = "low_quality.jpg";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange'/>
  <text x='100' y='115' font-size='30' text-anchor='middle' fill='white'>SVG</text>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // High quality conversion (default options)
            Aspose.Html.Saving.ImageSaveOptions highOptions = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, highOptions, highOutputPath);

            // Low quality conversion (default options)
            Aspose.Html.Saving.ImageSaveOptions lowOptions = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, lowOptions, lowOutputPath);

            // Compare file sizes
            long highSize = new FileInfo(highOutputPath).Length;
            long lowSize = new FileInfo(lowOutputPath).Length;

            if (highSize > lowSize)
            {
                Console.WriteLine("High quality image is larger than low quality image.");
            }
            else if (lowSize > highSize)
            {
                Console.WriteLine("Low quality image is larger than high quality image.");
            }
            else
            {
                Console.WriteLine("Both images have the same size.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}