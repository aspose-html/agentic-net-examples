// Use custom PixelsPerInch to simulate high‑density displays when converting pixels to inches.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Image;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value and custom DPI (pixels per inch)
            double pixels = 300;
            double customDpi = 200;

            // Convert pixels to inches using the custom DPI
            double inches = pixels / customDpi;
            Console.WriteLine($"Pixels: {pixels}, Custom DPI: {customDpi}, Inches: {inches:F4}");

            // Load a simple HTML document from a string
            using HTMLDocument document = new HTMLDocument("<html><body><h1>Hello World</h1></body></html>");

            // Set rendering options with the custom DPI to simulate a high‑density display
            ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Png)
            {
                HorizontalResolution = (int)customDpi,
                VerticalResolution = (int)customDpi
            };

            // Render the HTML to an image file using the specified options
            using ImageDevice device = new ImageDevice(options, "output.png");
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}