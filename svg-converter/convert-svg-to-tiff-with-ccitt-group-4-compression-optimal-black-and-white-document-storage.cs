// Convert an SVG to TIFF with CCITT Group 4 compression for optimal black‑and‑white document storage.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Input SVG and output TIFF paths
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg xmlns=""http://www.w3.org/2000/svg"" width=""100"" height=""100""><rect width=""100"" height=""100"" fill=""black""/></svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options for TIFF with no compression
            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG has been successfully converted to TIFF at '{Path.GetFullPath(tiffPath)}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}