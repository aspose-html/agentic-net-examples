// Convert SVG to GIF with transparent background by configuring the conversion settings before execution.

using System;
using System.IO;
using System.Drawing;
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
            string inputPath = "sample.svg";
            string outputPath = "output.gif";

            if (!File.Exists(inputPath))
            {
                string svgContent = @"<svg xmlns='http://www.w3.org/2000/svg' width='200' height='200'>
  <rect width='200' height='200' fill='none' stroke='black'/>
  <circle cx='100' cy='100' r='80' fill='red' />
</svg>";
                File.WriteAllText(inputPath, svgContent);
            }

            using (SVGDocument document = new SVGDocument(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
                options.BackgroundColor = Color.Transparent;
                options.UseAntialiasing = true;

                Aspose.Html.Converters.Converter.ConvertSVG(document, options, outputPath);
            }

            Console.WriteLine("SVG has been successfully converted to GIF with transparent background.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}