// Convert EPUB to BMP using ImageSaveOptions.CssMediaType='screen' to emulate screen display styling during rendering.

using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.bmp";

            Stream stream = File.OpenRead(epubPath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            options.Css.MediaType = MediaType.Screen;
            Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}