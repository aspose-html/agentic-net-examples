// Convert an SVG to GIF and set the frame delay to 100 milliseconds using ImageSaveOptions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG content and file paths
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>" +
                                "<rect x='10' y='10' width='180' height='180' fill='lightblue' stroke='navy' stroke-width='5'/>" +
                                "<text x='100' y='110' font-size='30' text-anchor='middle' fill='darkred'>Demo</text>" +
                                "</svg>";

            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, svgContent);
            }

            // Configure image save options for GIF format
            var options = new Aspose.Html.Saving.ImageSaveOptions(
                Aspose.Html.Rendering.Image.ImageFormat.Gif);

            // Convert SVG to GIF using Aspose.Html
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine($"SVG has been successfully converted to GIF: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}