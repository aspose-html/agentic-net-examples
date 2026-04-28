// Use HtmlRenderer.RenderTo with an ImageDevice to produce a JPG from HTML while specifying 300 DPI resolution.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a file
            HTMLDocument document = new HTMLDocument("input.html");

            // Create rendering options for JPEG format with 300 DPI resolution
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;

            // Create an image device specifying the output JPEG file
            ImageDevice device = new ImageDevice(options, "output.jpg");

            // Render the HTML document to the image device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}