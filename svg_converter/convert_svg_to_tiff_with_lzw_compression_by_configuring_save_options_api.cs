// Convert an SVG to TIFF with LZW compression by configuring the appropriate save options in the API.

using System;
using Aspose.Html;
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
            string sourcePath = "input.svg";
            string outputPath = "output.tiff";

            SVGDocument document = new SVGDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.LZW;
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}