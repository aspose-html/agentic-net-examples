// Set PixelsPerInch to 72 to emulate CSS 72 PPI conversion for legacy browser compatibility.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            var options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;

            string sourcePath = "input.html";
            string outputPath = "output.jpg";

            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}