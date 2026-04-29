// Convert an SVG image to GIF format with default ImageSaveOptions via Converter.ConvertSVG.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

namespace SvgToGifExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string sourcePath = "input.svg";
                string outputPath = "output.gif";

                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);

                Converter.ConvertSVG(sourcePath, options, outputPath);
                Console.WriteLine("SVG converted to GIF successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}