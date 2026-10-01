// Transform an SVG file into a high‑resolution TIFF image using custom DPI settings in the converter.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample SVG content
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string svgPath = "sample.svg";
            File.WriteAllText(svgPath, svgContent);

            // Load SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Convert to TIFF
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;
            string tiffPath = "output.tiff";
            Aspose.Html.Converters.Converter.ConvertSVG(document, tiffOptions, tiffPath);

            // Convert to JPEG
            var jpegOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            jpegOptions.UseAntialiasing = true;
            jpegOptions.HorizontalResolution = 300;
            jpegOptions.VerticalResolution = 300;
            jpegOptions.BackgroundColor = System.Drawing.Color.White;
            string jpegPath = "output.jpg";
            Aspose.Html.Converters.Converter.ConvertSVG(document, jpegOptions, jpegPath);

            Console.WriteLine("SVG conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}