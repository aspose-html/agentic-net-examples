// Render an SVG diagram to PNG with anti‑aliasing enabled and custom DPI for clarity.

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
            string svgPath = "sample.svg";
            // Output image file paths
            string pngOutputPath = "output.png";
            string tiffOutputPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string minimalSvg = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""200"" height=""200""><rect width=""200"" height=""200"" fill=""red""/></svg>";
                File.WriteAllText(svgPath, minimalSvg);
            }

            // Load SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // PNG conversion options
            Aspose.Html.Saving.ImageSaveOptions pngOptions = new Aspose.Html.Saving.ImageSaveOptions();
            pngOptions.HorizontalResolution = 300;
            pngOptions.VerticalResolution = 300;
            pngOptions.BackgroundColor = System.Drawing.Color.White;
            pngOptions.UseAntialiasing = true;

            // Convert SVG to PNG
            Aspose.Html.Converters.Converter.ConvertSVG(document, pngOptions, pngOutputPath);
            Console.WriteLine($"SVG converted to PNG: {pngOutputPath}");

            // TIFF conversion options
            Aspose.Html.Saving.ImageSaveOptions tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffOutputPath);
            Console.WriteLine($"SVG converted to TIFF: {tiffOutputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}