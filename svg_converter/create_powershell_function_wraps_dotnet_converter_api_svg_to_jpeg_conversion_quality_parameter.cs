// Create a PowerShell function that wraps the .NET Converter API for SVG to JPEG conversion with quality parameter.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string svgPath = "input.svg";
            string outputPath = "output.jpg";
            int quality = 90;
            ConvertSvgToJpeg(svgPath, outputPath, quality);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ConvertSvgToJpeg(string svgPath, string outputPath, int quality)
    {
        ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
        Converter.ConvertSVG(svgPath, options, outputPath);
    }
}