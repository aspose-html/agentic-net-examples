// Use HtmlRenderer.RenderTo with an ImageDevice to produce a JPG from HTML while setting anti‑aliasing.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
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
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;
            ImageDevice device = new ImageDevice(options, outputPath);
            HtmlRenderer renderer = new HtmlRenderer();
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}