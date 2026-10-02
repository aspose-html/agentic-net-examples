// Override default PPI to 110 before converting pixel measurements for a specific design requirement.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample pixel value and custom PPI
            double widthPixels = 800;
            double customPpi = 110.0;
            double widthInches = widthPixels / customPpi;
            double widthMillimeters = widthInches * 25.4;
            Console.WriteLine($"Width: {widthPixels} pixels = {widthInches:F4} inches = {widthMillimeters:F2} mm");

            // HTML content to render
            string html = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
                var options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                {
                    HorizontalResolution = (int)customPpi,
                    VerticalResolution = (int)customPpi
                };
                using (var device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
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