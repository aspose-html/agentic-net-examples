// Configure ImageSaveOptions to set JPEG DPI to 300, then render a high‑resolution canvas and save.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            HTMLDocument document = new HTMLDocument("input.html");
            ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            ImageDevice device = new ImageDevice(options, "output.jpg");
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}