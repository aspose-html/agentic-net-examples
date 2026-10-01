// Apply LZW compression in ImageSaveOptions while converting SVG to TIFF.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG path and output TIFF path
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <circle cx=""100"" cy=""100"" r=""80"" fill=""green"" stroke=""black"" stroke-width=""2"" />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            var document = new Aspose.Html.Dom.Svg.SVGDocument(svgPath);

            // Configure image save options for TIFF
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
            options.Compression = Aspose.Html.Rendering.Image.Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine($"SVG has been successfully converted to TIFF at: {Path.GetFullPath(tiffPath)}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}