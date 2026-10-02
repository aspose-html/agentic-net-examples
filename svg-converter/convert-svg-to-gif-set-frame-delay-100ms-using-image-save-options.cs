// Convert an SVG to GIF and set the frame delay to 100 milliseconds using ImageSaveOptions.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input SVG and output GIF paths
            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
    <rect width='200' height='200' fill='orange' />
    <circle cx='100' cy='100' r='80' fill='blue' />
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            // Configure image save options for GIF format
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

            // Convert SVG to GIF
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}