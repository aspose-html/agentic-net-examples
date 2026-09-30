// Convert an SVG file to JPG with 72 DPI resolution and transparent background for web thumbnails.

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
            string documentPath = "input.svg";
            string savePath = "output.jpg";

            // Load SVG document
            SVGDocument document = new SVGDocument(documentPath);

            // Configure image save options
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            options.BackgroundColor = System.Drawing.Color.Transparent;

            // Convert SVG to JPG
            Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}