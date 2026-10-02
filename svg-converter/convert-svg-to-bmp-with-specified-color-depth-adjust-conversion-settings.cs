// Convert an SVG to BMP with a specified color depth by adjusting the conversion settings accordingly.

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
            string documentPath = "sample.svg";
            if (!File.Exists(documentPath))
            {
                string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                File.WriteAllText(documentPath, svgContent);
            }

            string savePath = "output.bmp";

            SVGDocument document = new SVGDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            options.BackgroundColor = System.Drawing.Color.White;
            options.UseAntialiasing = true;

            Aspose.Html.Converters.Converter.ConvertSVG(document, options, savePath);

            Console.WriteLine("SVG converted to BMP successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}