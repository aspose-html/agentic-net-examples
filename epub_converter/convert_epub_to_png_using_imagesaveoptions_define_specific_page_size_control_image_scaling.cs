// Convert EPUB to PNG with ImageSaveOptions defining a specific page size to control image scaling.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string epubPath = "input.epub";
            string outputPath = "output.png";

            using (Stream stream = File.OpenRead(epubPath))
            {
                ImageSaveOptions options = new ImageSaveOptions();
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;

                Page page = new Page(
                    new Size(800, 600),
                    new Margin(30, 20, 10, 10));
                options.PageSetup.AnyPage = page;

                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}