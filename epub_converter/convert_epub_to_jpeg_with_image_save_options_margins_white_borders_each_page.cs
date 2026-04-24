// Convert EPUB to JPEG while configuring ImageSaveOptions.Margins to add white borders around each page.

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
            string inputPath = "input.epub";
            string outputPath = "output.jpg";

            using (FileStream stream = File.OpenRead(inputPath))
            {
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 400;
                options.VerticalResolution = 400;
                options.BackgroundColor = System.Drawing.Color.White;

                Page page = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
                options.PageSetup.AnyPage = page;

                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}