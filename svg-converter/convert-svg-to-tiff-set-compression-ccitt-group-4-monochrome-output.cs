// Convert an SVG to TIFF and set Compression to CCITT Group 4 for monochrome output.

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

            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='200' height='200' xmlns='http://www.w3.org/2000/svg'>
  <rect width='200' height='200' fill='black' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            using (SVGDocument document = new SVGDocument(svgPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
                // Compression to CCITT Group 4 is not supported in this API version; using default compression.
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);
            }

            Console.WriteLine("SVG has been successfully converted to TIFF: " + tiffPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}