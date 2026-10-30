// Apply scaling factor of 1.5 in PageSetup to enlarge content when converting HTML to JPG.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1><p>This image is scaled by 1.5.</p></body></html>";

            // Define output path
            string outputPath = "output.jpg";

            // Base dimensions in pixels
            int baseWidth = 800;
            int baseHeight = 600;
            double scale = 1.5;

            // Configure image rendering options with scaling
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.PageSetup.AnyPage = new Page(new Size(
                Length.FromPixels((int)(baseWidth * scale)),
                Length.FromPixels((int)(baseHeight * scale))
            ));

            // Load the HTML document from the string
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            // Create an image device for rendering
            using (ImageDevice device = new ImageDevice(options, outputPath))
            {
                // Render the document to the image device
                document.RenderTo(device);
            }

            Console.WriteLine("HTML has been successfully converted to JPEG with scaling factor 1.5.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}