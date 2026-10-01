// Generate PNG snapshots of SVG graphics at multiple resolutions for responsive web assets.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a simple SVG file
            string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'><rect width='200' height='200' fill='red'/></svg>";
            string inputPath = "sample.svg";
            File.WriteAllText(inputPath, svgContent);

            // Output PNG path
            string pngPath = "output.png";

            // Load SVG document
            var svgDocument = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

            // Set PNG conversion options
            var pngOptions = new Aspose.Html.Saving.ImageSaveOptions();
            pngOptions.HorizontalResolution = 300;
            pngOptions.VerticalResolution = 300;
            pngOptions.BackgroundColor = Color.White;
            pngOptions.UseAntialiasing = true;

            // Convert SVG to PNG
            Aspose.Html.Converters.Converter.ConvertSVG(svgDocument, pngOptions, pngPath);

            // Output TIFF path
            string tiffPath = "output.tiff";

            // Set TIFF conversion options
            var tiffOptions = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            tiffOptions.Compression = Aspose.Html.Rendering.Image.Compression.None;
            tiffOptions.HorizontalResolution = 300;
            tiffOptions.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(svgDocument, tiffOptions, tiffPath);

            Console.WriteLine("SVG conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}