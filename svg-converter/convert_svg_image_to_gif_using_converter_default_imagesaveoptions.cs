// Convert an SVG image to GIF format with default ImageSaveOptions via Converter.ConvertSVG.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a simple SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                                "<rect x='10' y='10' width='180' height='180' fill='lightblue' stroke='navy' stroke-width='4'/>" +
                                "<text x='100' y='110' font-size='30' text-anchor='middle' fill='darkred'>Demo</text>" +
                                "</svg>";

            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.svg");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

            // Write SVG content to a file
            File.WriteAllText(inputPath, svgContent);

            // Configure image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert SVG to GIF
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to GIF at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}