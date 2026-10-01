// Load an SVG file from the local file system for conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";

            // Write SVG to a temporary file
            string inputPath = "sample.svg";
            File.WriteAllText(inputPath, svgContent);

            // Define output image path
            string outputPath = "output.jpg";

            // Set image save options to JPEG format
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine($"SVG successfully converted to JPEG: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}