// Log each SVG to TIFF conversion, noting compression type and resulting file dimensions.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path
            string svgPath = "sample.svg";
            // Output TIFF file path
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string minimalSvg = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <rect width=""200"" height=""200"" fill=""lightblue"" />
  <circle cx=""100"" cy=""100"" r=""80"" fill=""orange"" />
</svg>";
                File.WriteAllText(svgPath, minimalSvg);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options for TIFF
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300; // DPI
            options.VerticalResolution = 300;   // DPI

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG has been successfully converted to TIFF at '{Path.GetFullPath(tiffPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}