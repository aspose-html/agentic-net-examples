// Batch convert multiple SVG images to GIF format while applying custom ImageSaveOptions for each file.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputSvg";
            string outputFolder = "OutputImages";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a minimal SVG file
            string svgPath = Path.Combine(inputFolder, "sample.svg");
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            File.WriteAllText(svgPath, svgContent);

            // Set image conversion options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to JPEG
            string outputPath = Path.Combine(outputFolder, "sample.jpg");
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine($"SVG successfully converted to image: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}