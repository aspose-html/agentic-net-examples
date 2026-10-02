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
            string inputPath = "sample.epub";
            string outputPath = "output.bmp";

            Stream stream = File.OpenRead(inputPath);

            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Bmp);
            Page page = new Page(
                new Size(800, 600),
                new Margin(10, 10, 10, 10));
            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}