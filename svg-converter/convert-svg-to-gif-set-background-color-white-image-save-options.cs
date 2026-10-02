// Convert an SVG to GIF and set background color to white using ImageSaveOptions.

using System;
using System.IO;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.svg";
                string outputPath = "output.gif";

                if (!File.Exists(inputPath))
                {
                    string svgContent = "<svg xmlns='http://www.w3.org/2000/svg' width='100' height='100'><rect width='100' height='100' fill='red'/></svg>";
                    File.WriteAllText(inputPath, svgContent);
                }

                Aspose.Html.Dom.Svg.SVGDocument document = new Aspose.Html.Dom.Svg.SVGDocument(inputPath);

                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.BackgroundColor = Color.White;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
                Console.WriteLine("SVG converted to GIF successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}