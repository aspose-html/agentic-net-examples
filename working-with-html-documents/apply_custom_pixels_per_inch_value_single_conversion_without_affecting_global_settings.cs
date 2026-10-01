// Apply custom PixelsPerInch value only for a single conversion operation without affecting global settings.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeters conversion
            double pixels = 300;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Pixel count to inches conversion
            double pixelCount = 1200;
            double inches = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches:F4} }}");

            // Length in centimeters
            double centimeters = pixels / 96.0 * 2.54;
            Console.WriteLine($"Length in centimeters: {{ {centimeters:F2} }}");

            // Custom DPI conversion
            double customDpi = 150;
            double inchesCustom = pixels / customDpi;
            Console.WriteLine($"Pixels: {{ {pixels} }}, Custom DPI: {{ {customDpi} }}, Inches: {{ {inchesCustom:F4} }}");

            // Create HTML document from a string
            string htmlContent = "<html><body><h1>Hello Aspose.HTML</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                // Set up image rendering options with custom DPI
                Aspose.Html.Rendering.Image.ImageRenderingOptions options =
                    new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                    {
                        HorizontalResolution = (int)customDpi,
                        VerticalResolution = (int)customDpi
                    };

                // Render to PNG file
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                using (Aspose.Html.Rendering.Image.ImageDevice device =
                    new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("HTML rendered to PNG successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}