// Set GIF resolution to 300 DPI via ImageSaveOptions when converting HTML to GIF format.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.gif";

            HTMLDocument document = new HTMLDocument(inputPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}