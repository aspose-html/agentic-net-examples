// Convert an SVG to GIF while preserving animation frames using appropriate ImageSaveOptions settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a minimal SVG file
            string inputSvgPath = "sample.svg";
            string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='orange' />
</svg>";
            File.WriteAllText(inputSvgPath, svgContent);

            // Define output path
            string outputPath = "output.gif";

            // Set image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert SVG to GIF
            Aspose.Html.Converters.Converter.ConvertSVG(inputSvgPath, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to GIF at '{Path.GetFullPath(outputPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}