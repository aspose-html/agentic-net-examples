// Override default PPI to 100 before converting pixel values for a custom design system.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load HTML document from inline content
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Custom DPI (PPI) for the design system
                double customDpi = 100.0;

                // Example: convert pixel value to inches using custom DPI
                double pixels = 200.0;
                double inches = pixels / customDpi;
                Length length = Length.FromInches(inches);
                Console.WriteLine($"Pixels: {pixels}, Custom DPI: {customDpi}, Inches: {inches:F4}, Length: {length}");

                // Set up image rendering options with custom DPI
                ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Png)
                {
                    HorizontalResolution = (int)customDpi,
                    VerticalResolution = (int)customDpi
                };

                // Output image path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");

                // Render HTML to PNG image using custom DPI
                using (ImageDevice device = new ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Rendered image saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}