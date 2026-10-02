// Convert an SVG file to JPG with 72 DPI resolution and transparent background for web thumbnails.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.svg";
            string outputPath = "thumbnail.jpg";

            if (!File.Exists(inputPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            SVGDocument document = new SVGDocument(inputPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            options.BackgroundColor = Color.Transparent;
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine("Conversion completed: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}