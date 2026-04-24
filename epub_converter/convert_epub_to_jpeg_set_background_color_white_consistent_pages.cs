// Convert EPUB to JPEG and set ImageSaveOptions.BackgroundColor to white for consistent background across pages.

using System;
using System.IO;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            System.IO.Stream stream = File.OpenRead("input.epub");
            System.String outputPath = "output.jpg";

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.HorizontalResolution = 400;
            options.VerticalResolution = 400;
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(800, 500),
                new Aspose.Html.Drawing.Margin(30, 20, 10, 10));

            options.PageSetup.AnyPage = page;

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}