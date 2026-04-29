// Apply LZW compression in ImageSaveOptions while converting SVG to TIFF.

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
            string outputTiff = "output.tiff";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff);
            options.Compression = Compression.LZW;

            Converter.ConvertSVG(sourceSvg, options, outputTiff);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}