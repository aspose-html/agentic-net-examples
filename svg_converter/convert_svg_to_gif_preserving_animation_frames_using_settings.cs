// Convert an SVG to GIF while preserving animation frames using appropriate ImageSaveOptions settings.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string sourceSvg = "input.svg";
            string outputGif = "output.gif";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            Converter.ConvertSVG(sourceSvg, options, outputGif);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}