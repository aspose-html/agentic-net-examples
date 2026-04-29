// Convert an SVG to BMP with a specified color depth by adjusting the conversion settings accordingly.

using System;
using System.Drawing;
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
            string documentPath = "input.svg";
            string savePath = "output.bmp";

            SVGDocument document = new SVGDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            options.BackgroundColor = Color.AliceBlue;
            options.UseAntialiasing = true;

            Converter.ConvertSVG(document, options, savePath);
            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}