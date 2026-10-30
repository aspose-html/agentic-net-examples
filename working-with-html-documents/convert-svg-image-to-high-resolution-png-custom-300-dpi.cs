// Convert an SVG image to a high‑resolution PNG file with a custom 300 DPI setting.

using System;
using System.IO;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input SVG and output PNG paths
            string svgPath = "sample.svg";
            string pngPath = "output.png";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<svg width=""200"" height=""200"" xmlns=""http://www.w3.org/2000/svg"">
  <circle cx=""100"" cy=""100"" r=""80"" fill=""green"" stroke=""black"" stroke-width=""2""/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Load the SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Configure image save options for high resolution PNG
            ImageSaveOptions options = new ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.UseAntialiasing = true;

            // Convert SVG to PNG with the specified options
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, pngPath);

            Console.WriteLine($"SVG has been converted to high‑resolution PNG at: {Path.GetFullPath(pngPath)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}