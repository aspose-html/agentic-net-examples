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

            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><circle cx='50' cy='50' r='40' fill='red'/></svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 256;
            options.VerticalResolution = 256;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);

            Console.WriteLine($"SVG has been rendered to PNG at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}