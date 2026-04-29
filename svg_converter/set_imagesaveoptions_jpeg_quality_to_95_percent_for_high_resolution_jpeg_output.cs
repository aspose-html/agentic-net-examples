// Set ImageSaveOptions JPEG quality to 95 percent for high‑resolution JPEG output.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            var options = new ImageSaveOptions(ImageFormat.Jpeg);
            // JPEG quality defaults to 95% in Aspose.HTML
            string inputSvg = "input.svg";
            string outputJpeg = "output.jpg";
            Converter.ConvertSVG(inputSvg, options, outputJpeg);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}