// Render an EPUB document to PNG images, one image per page, preserving original dimensions.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputFolder = "output_images";

            Directory.CreateDirectory(outputFolder);

            Stream stream = File.OpenRead(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.UseAntialiasing = true;
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 96;
            options.VerticalResolution = 96;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputFolder);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}