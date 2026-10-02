// Use custom PixelsPerInch to simulate high‑density displays when converting pixels to inches.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value and custom DPI (pixels per inch)
            double pixels = 450.0;
            double customDpi = 300.0;

            // Convert pixels to inches using custom DPI
            double inches = pixels / customDpi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {pixels}, Custom DPI: {customDpi}, Inches: {inches:F4}");

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Set up image rendering options with custom resolution
                Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                    new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                    {
                        HorizontalResolution = (int)customDpi,
                        VerticalResolution = (int)customDpi
                    };

                string outputPath = "output.png";

                // Render HTML to PNG image using the custom DPI settings
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Rendered image saved to: {Path.GetFullPath(outputPath)}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}