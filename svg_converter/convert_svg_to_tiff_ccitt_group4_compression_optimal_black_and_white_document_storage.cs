// Convert an SVG to TIFF with CCITT Group 4 compression for optimal black‑and‑white document storage.

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
            string outputPath = "output.tiff";

            SVGDocument document = new SVGDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.None; // CCITT Group 4 compression not available in this API version
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