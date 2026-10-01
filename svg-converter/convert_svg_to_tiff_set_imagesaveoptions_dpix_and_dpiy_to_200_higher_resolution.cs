// Convert an SVG to TIFF and set ImageSaveOptions.DpiX and DpiY to 200 for higher resolution.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG file path and output TIFF file path
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a simple SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='red' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Set up image save options for TIFF
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG successfully converted to TIFF: {tiffPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}