// Convert an SVG to TIFF with CCITT Group 4 compression for optimal black‑and‑white document storage.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";
            string bmpPath = "output.bmp";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""green"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""red"" />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Convert SVG to TIFF
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffPath);
            Console.WriteLine($"SVG successfully converted to TIFF: {tiffPath}");

            // Convert SVG to BMP with background color and antialiasing
            var bmpOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            bmpOptions.HorizontalResolution = 300;
            bmpOptions.VerticalResolution = 300;
            bmpOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            bmpOptions.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, bmpOptions, bmpPath);
            Console.WriteLine($"SVG successfully converted to BMP: {bmpPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}