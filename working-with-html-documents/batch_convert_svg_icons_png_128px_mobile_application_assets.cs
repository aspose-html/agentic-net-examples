// Batch convert SVG icons to PNG format at 128 px size for mobile application assets.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='lightblue'/>
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
            string inputPath = "sample.svg";
            File.WriteAllText(inputPath, svgContent);

            string outputPath = "sample.png";

            // Create ImageSaveOptions for PNG
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Load SVG document and convert
            using (var document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath))
            {
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine($"SVG converted to PNG successfully: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}