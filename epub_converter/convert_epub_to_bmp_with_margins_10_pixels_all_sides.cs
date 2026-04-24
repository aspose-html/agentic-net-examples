// Convert EPUB to BMP with ImageSaveOptions.Margins set to 10 pixels on all sides.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.bmp";

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
                options.PageSetup.AnyPage = new Page(new Size(800, 600), new Margin(10, 10, 10, 10));
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}