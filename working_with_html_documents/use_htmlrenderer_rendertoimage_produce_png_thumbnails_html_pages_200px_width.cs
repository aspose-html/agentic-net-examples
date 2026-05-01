// Use HtmlRenderer.RenderToImage to produce PNG thumbnails of HTML pages at 200 px width.

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
            // Input HTML file and output PNG thumbnail paths
            string htmlPath = "input.html";
            string outputPath = "thumbnail.png";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create rendering options (default format is PNG)
            ImageRenderingOptions options = new ImageRenderingOptions();

            // Set the desired thumbnail width (200 px). Height is set to 0 to let the renderer calculate it.
            options.PageSetup.AnyPage = new Page(new Size(200, 0));

            // Create an image device with the options and output path
            ImageDevice device = new ImageDevice(options, outputPath);

            // Render the HTML to the image device (produces the PNG thumbnail)
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}