// Load SVG content from a file and convert it to JPEG image using ImageDevice with quality parameter.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare a minimal SVG file if it does not exist
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange' stroke='black' stroke-width='5'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Define output JPEG path
            string outputPath = "output.jpg";

            // Set JPEG image save options
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Jpeg);

            // Convert SVG to JPEG
            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine($"SVG file '{svgPath}' has been successfully converted to JPEG at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}