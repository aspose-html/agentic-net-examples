// Load SVG content from a file and convert it to JPEG image using ImageDevice with quality parameter.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(svgPath))
            {
                string sampleSvg = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='lightblue'/><circle cx='100' cy='100' r='80' stroke='navy' stroke-width='5' fill='orange' /></svg>";
                File.WriteAllText(svgPath, sampleSvg);
            }

            ImageSaveOptions options = new ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            // options.Quality = 80; // Uncomment if Quality property is supported

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            Console.WriteLine("SVG has been successfully converted to JPEG: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}