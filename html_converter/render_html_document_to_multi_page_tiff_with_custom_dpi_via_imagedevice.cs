// Render an HTML document to a multi‑page TIFF image with custom DPI settings via ImageDevice.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Saving;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.tiff";

            HTMLDocument document = new HTMLDocument(inputPath);

            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Tiff);
            options.Compression = Compression.None;
            options.BackgroundColor = Color.White;
            options.HorizontalResolution = 150;
            options.VerticalResolution = 150;

            ImageDevice device = new ImageDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}