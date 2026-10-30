// Use custom PixelsPerInch to simulate high‑density displays when converting pixels to inches.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value and custom DPI (pixels per inch)
            double pixels = 300.0;
            double customDpi = 300.0;

            // Convert pixels to inches using the custom DPI
            double inches = pixels / customDpi;
            System.Console.WriteLine($"Pixels: {pixels}, Custom DPI: {customDpi}, Inches: {inches:F4}");

            // Create a simple HTML document (inline content)
            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Set up image rendering options with the custom DPI
                Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                    new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                    {
                        HorizontalResolution = (int)customDpi,
                        VerticalResolution = (int)customDpi
                    };

                // Render the HTML to a PNG image using the custom DPI
                string outputPath = "output.png";
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine($"Rendered image saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}