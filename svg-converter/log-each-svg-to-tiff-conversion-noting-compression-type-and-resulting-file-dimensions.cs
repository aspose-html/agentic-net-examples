// Log each SVG to TIFF conversion, noting compression type and resulting file dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'><rect width='200' height='100' fill='red'/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Define output TIFF path
            string tiffPath = "output.tiff";

            // Load SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            // Load resulting TIFF to get dimensions
            using (Image img = Image.FromFile(tiffPath))
            {
                Console.WriteLine($"Converted '{svgPath}' to '{tiffPath}'.");
                Console.WriteLine($"Compression: {options.Compression}");
                Console.WriteLine($"Dimensions: {img.Width}x{img.Height}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}