// Convert an SVG to BMP with a specified color depth by adjusting the conversion settings accordingly.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG content
            string documentPath = "sample.svg";
            string savePath = "output.bmp";

            if (!File.Exists(documentPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
  <text x=""100"" y=""115"" font-size=""30"" text-anchor=""middle"" fill=""white"">SVG</text>
</svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            // Set image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            // Load SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(documentPath);

            // Convert SVG to BMP
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

            Console.WriteLine($"SVG has been successfully converted to BMP at '{Path.GetFullPath(savePath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}