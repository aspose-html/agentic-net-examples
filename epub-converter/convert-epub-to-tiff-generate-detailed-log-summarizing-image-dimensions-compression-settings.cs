// Convert EPUB to TIFF and generate a detailed log entry summarizing image dimensions and compression settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.tiff";

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff)
                {
                    Compression = Aspose.Html.Rendering.Image.Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 300,
                    VerticalResolution = 300,
                    BackgroundColor = System.Drawing.Color.White
                };

                var page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 1200),
                    new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

                options.PageSetup.AnyPage = page;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
            }

            Console.WriteLine("EPUB to TIFF conversion completed.");
            Console.WriteLine("Output file: " + outputPath);
            Console.WriteLine("Image format: TIFF");
            Console.WriteLine("Page size: 800x1200 pixels");
            Console.WriteLine("Compression: None");
            Console.WriteLine("Resolution: 300 DPI (horizontal) x 300 DPI (vertical)");
            Console.WriteLine("Background color: White");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}