// Convert a single SVG file to BMP using the one‑line Converter.ConvertSVG method.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG file path and output BMP file path
            string sourcePath = "sample.svg";
            string outputPath = "output.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(sourcePath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                                    "<rect width='200' height='200' fill='red'/>" +
                                    "</svg>";
                File.WriteAllText(sourcePath, svgContent);
            }

            // Configure image save options for BMP format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = Color.White;
            options.UseAntialiasing = true;

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(sourcePath, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to BMP at: {Path.GetFullPath(outputPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}