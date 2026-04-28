// Configure ImageRenderingOptions to set both resolution and background color for consistent JPG output across conversions.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.jpg";

            HTMLDocument document = new HTMLDocument(htmlPath);

            ImageRenderingOptions options = new ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.BackgroundColor = Color.White;

            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}