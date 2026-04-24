// Apply a uniform DPI setting in ImageSaveOptions to ensure consistent resolution across all GIF pages.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Drawing;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.gif";
            HTMLDocument document = new HTMLDocument("input.html");
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Gif);
            options.UseAntialiasing = false;
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.PageSetup.AnyPage = new Page(new Size(500, 200), new Margin(30, 20, 10, 10));
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}