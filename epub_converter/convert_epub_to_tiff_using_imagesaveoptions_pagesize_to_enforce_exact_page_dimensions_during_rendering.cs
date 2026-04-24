// Convert EPUB to TIFF using ImageSaveOptions.PageSize to enforce exact page dimensions during rendering.

using System;
using System.IO;
using Aspose.Html;
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
            using (Stream stream = File.OpenRead("input.epub"))
            {
                string outputPath = "output.tiff";
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Tiff)
                {
                    Compression = Compression.None,
                    UseAntialiasing = true,
                    HorizontalResolution = 400,
                    VerticalResolution = 400,
                    BackgroundColor = System.Drawing.Color.White
                };
                options.PageSetup.AnyPage = new Page(new Size(800, 500), new Margin(30, 20, 10, 10));
                Converter.ConvertEPUB(stream, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}