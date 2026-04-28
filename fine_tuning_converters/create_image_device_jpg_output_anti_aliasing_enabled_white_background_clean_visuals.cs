// Create an ImageDevice for JPG output with anti‑aliasing enabled and a white background for clean visuals.

using System;
using System.Drawing;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Load an HTML document (replace with your actual file path)
            HTMLDocument document = new HTMLDocument("input.html");

            // Create rendering options for JPEG format
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Jpeg);
            options.UseAntialiasing = true;               // Enable anti‑aliasing
            options.BackgroundColor = Color.White;        // Set white background

            // Create an ImageDevice with the specified options and output file
            ImageDevice device = new ImageDevice(options, "output.jpg");

            // Render the document to the device (optional, based on your needs)
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}