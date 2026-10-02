// Convert an SVG image to GIF format with default ImageSaveOptions via Converter.ConvertSVG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output GIF file paths
            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Set image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert SVG to GIF
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine($"SVG file '{inputPath}' was successfully converted to GIF '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}