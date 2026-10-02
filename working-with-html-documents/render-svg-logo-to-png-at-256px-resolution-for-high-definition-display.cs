// Render an SVG logo to PNG at 256 px resolution for high‑definition display usage.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "logo.svg";
            string outputPath = "logo.png";

            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='256' height='256'><rect width='256' height='256' fill='blue'/></svg>";
            File.WriteAllText(inputPath, svgContent);

            var document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

            var options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 256;
            options.VerticalResolution = 256;
            options.BackgroundColor = Color.Transparent;
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}