// Convert an SVG to BMP with antialiasing enabled and verify image sharpness after conversion.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path
            string sourcePath = "sample.svg";
            // Output BMP file path
            string outputPath = "output.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='red' />
  <circle cx='100' cy='100' r='80' fill='green' />
</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG successfully converted to BMP: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}