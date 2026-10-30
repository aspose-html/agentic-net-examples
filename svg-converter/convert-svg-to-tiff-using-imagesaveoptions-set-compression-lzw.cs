// Convert an SVG file to TIFF using ImageSaveOptions and set Compression to LZW.

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
            // Prepare sample SVG file
            string svgPath = "sample.svg";
            if (!File.Exists(svgPath))
            {
                string svgContent = @"<svg width='100' height='100' xmlns='http://www.w3.org/2000/svg'>
  <circle cx='50' cy='50' r='40' stroke='green' stroke-width='4' fill='yellow' />
</svg>";
                File.WriteAllText(svgPath, svgContent);
            }

            // Output TIFF path
            string tiffPath = "output.tiff";

            // Load SVG document
            SVGDocument document = new SVGDocument(svgPath);

            // Configure image save options for TIFF with LZW compression
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.LZW;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Convert SVG to TIFF
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, tiffPath);

            Console.WriteLine("SVG has been successfully converted to TIFF at: " + Path.GetFullPath(tiffPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}