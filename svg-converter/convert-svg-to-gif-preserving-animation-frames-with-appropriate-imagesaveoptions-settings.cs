// Convert an SVG to GIF while preserving animation frames using appropriate ImageSaveOptions settings.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.svg";
            string outputPath = "animated.gif";

            // Create a simple animated SVG if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='50' cy='50' r='40' fill='red'>
    <animate attributeName='fill' values='red;blue;green;red' dur='4s' repeatCount='indefinite' />
  </circle>
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Set image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert SVG to animated GIF
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}