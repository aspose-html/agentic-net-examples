// Convert an SVG to TIFF with no compression by setting ImageSaveOptions.Compression to None.

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
            string outputPath = "output.tiff";

            SVGDocument document = new SVGDocument(svgPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}