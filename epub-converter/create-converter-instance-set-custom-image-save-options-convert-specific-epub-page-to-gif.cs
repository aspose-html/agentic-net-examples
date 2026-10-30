// Create a Converter instance, set custom ImageSaveOptions, and convert a specific EPUB page to GIF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.gif");

            using (FileStream stream = File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Gif);
                options.UseAntialiasing = true;
                options.HorizontalResolution = 300;
                options.VerticalResolution = 300;

                var pageSize = new Aspose.Html.Drawing.Size(800, 600);
                var margin = new Aspose.Html.Drawing.Margin(10, 10, 10, 10);
                var page = new Aspose.Html.Drawing.Page(pageSize, margin);
                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}