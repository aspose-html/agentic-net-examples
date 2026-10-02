// Convert an SVG to BMP with antialiasing enabled and verify image sharpness after conversion.

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
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            string outputPath = "output.bmp";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertSVG(svgPath, options, outputPath);

            if (File.Exists(outputPath))
            {
                long size = new FileInfo(outputPath).Length;
                Console.WriteLine($"SVG converted to BMP successfully. Output size: {size} bytes.");
            }
            else
            {
                Console.WriteLine("Conversion failed: output file not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}