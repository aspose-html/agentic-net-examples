// Convert an SVG to GIF while preserving animation frames using appropriate ImageSaveOptions settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='red'>
    <animate attributeName='fill' values='red;blue;green;red' dur='4s' repeatCount='indefinite' />
  </rect>
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine("SVG converted to GIF successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}