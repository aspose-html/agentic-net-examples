// Convert SVG to JPG using ImageDevice, specifying 72 DPI resolution for web‑optimized image size.

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
            string sourcePath = "input.svg";
            string outputPath = "output.jpg";

            SVGDocument document = new SVGDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            Converter.ConvertSVG(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}