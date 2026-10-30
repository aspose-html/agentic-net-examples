// Override default PPI to 110 before converting pixel measurements for a specific design requirement.

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
            // Define custom PPI
            const double customPpi = 110.0;

            // Sample pixel measurement
            double widthPixels = 220.0;
            double heightPixels = 110.0;

            // Convert pixels to inches using custom PPI
            double widthInches = widthPixels / customPpi;
            double heightInches = heightPixels / customPpi;

            // Create Length objects from inches
            Length widthLength = Length.FromInches(widthInches);
            Length heightLength = Length.FromInches(heightInches);

            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in");

            // Prepare simple HTML content
            string htmlContent = $"<html><body><div style='width:{widthPixels}px;height:{heightPixels}px;background:#4CAF50;'></div></body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Set up image rendering options with custom resolution
                ImageRenderingOptions options = new ImageRenderingOptions(ImageFormat.Png)
                {
                    HorizontalResolution = (int)customPpi,
                    VerticalResolution = (int)customPpi
                };

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.png");
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