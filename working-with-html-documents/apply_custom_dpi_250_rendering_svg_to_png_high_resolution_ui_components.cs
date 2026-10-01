// Apply a custom DPI of 250 when rendering SVG to PNG for high‑resolution UI components.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path
            System.String svgPath = "sample.svg";
            // Output image file paths
            System.String pngOutputPath = "output.png";
            System.String tiffOutputPath = "output.tiff";

            // Ensure a minimal SVG file exists
            if (!File.Exists(svgPath))
            {
                System.String svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // First conversion: PNG with basic options
            Aspose.Html.Saving.ImageSaveOptions pngOptions = new Aspose.Html.Saving.ImageSaveOptions();
            pngOptions.HorizontalResolution = 300;
            pngOptions.VerticalResolution = 300;
            pngOptions.BackgroundColor = System.Drawing.Color.White;
            pngOptions.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, pngOptions, pngOutputPath);
            Console.WriteLine($"PNG image saved to: {pngOutputPath}");

            // Second conversion: TIFF with specific format and compression
            Aspose.Html.Saving.ImageSaveOptions tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffOutputPath);
            Console.WriteLine($"TIFF image saved to: {tiffOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}