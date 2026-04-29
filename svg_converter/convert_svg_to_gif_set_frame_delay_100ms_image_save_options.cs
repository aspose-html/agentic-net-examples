// Convert an SVG to GIF and set the frame delay to 100 milliseconds using ImageSaveOptions.

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
            string sourcePath = "input.svg";
            string outputPath = "output.gif";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            // The ImageSaveOptions class does not expose a FrameDelay property in this version.
            // Therefore, setting a specific frame delay is not supported and is omitted.

            Converter.ConvertSVG(sourcePath, options, outputPath);
            Console.WriteLine("SVG has been successfully converted to GIF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}