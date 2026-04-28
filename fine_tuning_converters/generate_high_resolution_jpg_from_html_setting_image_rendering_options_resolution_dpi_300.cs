// Generate a high‑resolution JPG from HTML by setting ImageRenderingOptions.ResolutionDpi to 300 DPI.

using System;
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
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.VerticalResolution = 300;
            options.HorizontalResolution = 300;

            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}