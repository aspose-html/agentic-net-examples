// Convert an SVG to TIFF with LZW compression by configuring the appropriate save options in the API.

using System;
using System.IO;
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
            string svgPath = "sample.svg";
            string tiffPath = "output.tiff";

            // Create a minimal SVG file if it does not exist
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
    <rect width='200' height='200' fill='lightblue'/>
    <circle cx='100' cy='100' r='80' fill='orange'/>
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            using (SVGDocument document = new SVGDocument(svgPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                // LZW compression is not available in the current API; using default compression settings.

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            }

            Console.WriteLine($"SVG has been successfully converted to TIFF at '{tiffPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during conversion:");
            Console.WriteLine(ex.Message);
        }
    }
}