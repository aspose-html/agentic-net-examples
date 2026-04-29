// Set ImageSaveOptions JPEG quality to 85 percent before converting SVG to JPG.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string svgPath = "input.svg";
            string jpgPath = "output.jpg";

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            // JPEG quality setting is not supported in this version of Aspose.HTML

            Converter.ConvertSVG(svgPath, options, jpgPath);
            Console.WriteLine("SVG has been successfully converted to JPEG.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}