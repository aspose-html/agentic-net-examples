// Set custom DPI of 96 in ImageSaveOptions before converting HTML to BMP for standard screen display.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string documentPath = "input.html";
            string savePath = "output.bmp";
            HTMLDocument document = new HTMLDocument(documentPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}