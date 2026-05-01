// Render the converted HTML document to PNG with a specified image width and height.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string outputPath = "output.png";
            int width = 800;
            int height = 600;

            // Configure image rendering options for PNG format
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Png);
            // Set the desired image size
            options.PageSetup.AnyPage = new Page(new Size(width, height));

            // Create an image device with the options and output file path
            ImageDevice device = new ImageDevice(options, outputPath);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Render the document to the image device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}