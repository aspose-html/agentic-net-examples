// Convert HTML to GIF while configuring resolution and rendering quality using ImageSaveOptions.

using System;
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
            string sourcePath = "input.html";
            string outputPath = "output.gif";

            HTMLDocument document = new HTMLDocument(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.PageSetup.AnyPage = new Page(new Size(800, 600), new Margin(10, 10, 10, 10));

            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}