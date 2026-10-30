// Create an ImageDevice for JPG output with anti‑aliasing enabled and a white background for clean visuals.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, "output.jpg");
            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}