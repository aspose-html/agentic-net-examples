// Load an SVG file from the local file system for conversion.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='blue'/></svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            Aspose.Html.Converters.Converter.ConvertSVG(inputPath, options, outputPath);

            Console.WriteLine("SVG converted to image successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}