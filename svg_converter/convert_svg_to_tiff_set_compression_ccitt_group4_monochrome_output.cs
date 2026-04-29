// Convert an SVG to TIFF and set Compression to CCITT Group 4 for monochrome output.

using System;
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
            string svgPath = "input.svg";
            string tiffPath = "output.tiff";
            SVGDocument document = new SVGDocument(svgPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            Converter.ConvertSVG(document, options, tiffPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}