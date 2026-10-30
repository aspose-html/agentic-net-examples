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
            string[] svgPaths = { "sample1.svg", "sample2.svg" };
            string[] svgContents = {
                @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='100'><rect width='200' height='100' fill='red'/></svg>",
                @"<svg xmlns='http://www.w3.org/2000/svg' width='150' height='150'><circle cx='75' cy='75' r='70' fill='green'/></svg>"
            };

            for (int i = 0; i < svgPaths.Length; i++)
            {
                string svgPath = svgPaths[i];
                if (!File.Exists(svgPath))
                {
                    File.WriteAllText(svgPath, svgContents[i]);
                }

                string tiffPath = Path.ChangeExtension(svgPath, ".tiff");

                // Load SVG document
                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

                // Set image save options
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                options.Compression = Aspose.Html.Rendering.Image.Compression.None;
                options.HorizontalResolution = 96;
                options.VerticalResolution = 96;

                // Convert SVG to TIFF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

                // Get resulting image dimensions
                using (Image img = Image.FromFile(tiffPath))
                {
                    Console.WriteLine($"Converted '{svgPath}' to '{tiffPath}'. Compression: {options.Compression}. Dimensions: {img.Width}x{img.Height}.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}