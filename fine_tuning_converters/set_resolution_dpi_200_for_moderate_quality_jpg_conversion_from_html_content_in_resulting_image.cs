// Set ImageRenderingOptions.ResolutionDpi to 200 for moderate‑quality JPG conversion from HTML content in the resulting image.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the JPEG image will be saved
            string outputPath = "output.jpg";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create rendering options for JPEG format
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);

            // Set moderate quality by disabling antialiasing (optional)
            options.UseAntialiasing = false;

            // Set both horizontal and vertical resolution to 200 DPI
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;

            // Create an image device with the options and output path
            ImageDevice device = new ImageDevice(options, outputPath);

            // Render the HTML document to the image device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}