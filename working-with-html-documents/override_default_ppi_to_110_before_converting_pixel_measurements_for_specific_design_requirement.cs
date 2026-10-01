// Override default PPI to 110 before converting pixel measurements for a specific design requirement.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Pixel to millimeter conversion
            double pixels = 300.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            // Pixel to inches and Length conversion
            double inches = pixels / ppi;
            Aspose.Html.Drawing.Length length = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Pixels: {{ {pixels} }}, PPI: {{ {ppi} }}, Inches: {{ {inches:F4} }}");

            // Width/Height conversions
            double widthPixels = 800;
            double heightPixels = 600;

            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthCentimeters:F4} cm = {widthMillimeters:F2} mm = {widthPoints:F2} pt = {widthPicas:F2} pc");
            Console.WriteLine($"Height: {heightPixels} px = {heightInches:F4} in = {heightCentimeters:F4} cm = {heightMillimeters:F2} mm = {heightPoints:F2} pt = {heightPicas:F2} pc");

            // Render HTML to PNG with custom DPI
            double customDpi = 150.0;
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose HTML</h1></body></html>";
            string inputPath = "sample.html";
            string outputPath = "output.png";

            // Create a minimal HTML file
            File.WriteAllText(inputPath, htmlContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
            {
                Aspose.Html.Rendering.Image.ImageRenderingOptions options = new Aspose.Html.Rendering.Image.ImageRenderingOptions(Aspose.Html.Rendering.Image.ImageFormat.Png)
                {
                    HorizontalResolution = (int)customDpi,
                    VerticalResolution = (int)customDpi
                };

                using (Aspose.Html.Rendering.Image.ImageDevice device = new Aspose.Html.Rendering.Image.ImageDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine($"HTML rendered to PNG at '{outputPath}' with DPI {customDpi}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}