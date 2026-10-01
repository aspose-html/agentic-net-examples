// Convert an SVG to TIFF and set Compression to CCITT Group 4 for monochrome output.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output TIFF paths
            string svgPath = "sample.svg";
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
            using (SVGDocument document = new SVGDocument(svgPath))
            {
                // Configure image save options for TIFF
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.Compression = Compression.None;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                // Convert SVG to TIFF
                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            }

            Console.WriteLine($"SVG has been successfully converted to TIFF: {Path.GetFileName(tiffPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}