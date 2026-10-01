// Convert EPUB to JPEG while configuring ImageSaveOptions.Margins to add white borders around each page.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.epub");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.jpg");

            using (FileStream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                options.UseAntialiasing = true;
                options.BackgroundColor = System.Drawing.Color.White;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1000),
                    new Aspose.Html.Drawing.Margin(50, 50, 50, 50));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during EPUB to JPEG conversion: " + ex.Message);
        }
    }
}