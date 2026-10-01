// Override default PPI to 100 before converting pixel values for a custom design system.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // 1. Pixels to millimeters
            double pixels = 300.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // 2. Pixels to inches and Length from inches
            double pixels2 = 200.0;
            double ppi2 = 120.0;
            double inches = pixels2 / ppi2;
            Aspose.Html.Drawing.Length lengthFromInches = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {{ {pixels2} }}, PPI: {{ {ppi2} }}, Inches: {{ {inches:F4} }}");
            Console.WriteLine($"Length from inches: {{ {lengthFromInches} }}");

            // 3. Render HTML to PNG with custom DPI
            double pixels3 = 400.0;
            double customDpi = 150.0;
            double inches3 = pixels3 / customDpi;

            // Create a minimal HTML file
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";
            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                {
                    HorizontalResolution = (int)customDpi,
                    VerticalResolution = (int)customDpi
                };

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Rendered image saved to: {outputPath}");
            }

            // 4. Pixels to points and Length from pixels
            double pixels4 = 500.0;
            const double ppi4 = 96.0;
            const double pointsPerInch = 72.0;
            Aspose.Html.Drawing.Length lengthFromPixels = Aspose.Html.Drawing.Length.FromPixels(pixels4);
            double points = pixels4 * (pointsPerInch / ppi4);
            Console.WriteLine($"Length: {{ {lengthFromPixels} }}; points: {{ {points:F2} }}");

            // 5. Pixel count to inches
            double pixelCount = 800.0;
            double inches4 = pixelCount / 96.0;
            Console.WriteLine($"Pixel count: {{ {pixelCount} }} => Inches: {{ {inches4:F4} }}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}