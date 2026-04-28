// Generate a JPG from SVG using ImageDevice with 300 DPI resolution and white background color.

using System;
using Aspose.Html.Dom.Svg;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using System.Drawing;

namespace SvgToJpeg
{
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
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;
                options.BackgroundColor = Color.White;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}