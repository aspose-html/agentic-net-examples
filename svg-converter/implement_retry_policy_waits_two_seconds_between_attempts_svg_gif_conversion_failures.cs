// Implement a retry policy that waits two seconds between attempts for SVG to GIF conversion failures.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.svg");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='red' />
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

            // Configure image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to GIF and save to file
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine($"SVG successfully converted to GIF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}