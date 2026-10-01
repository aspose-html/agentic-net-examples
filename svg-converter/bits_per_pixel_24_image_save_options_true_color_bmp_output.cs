// Specify BitsPerPixel equal to 24 in ImageSaveOptions for true‑color BMP output.

using System;
using System.Drawing;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Create HTML document from string
            var document = new Aspose.Html.HTMLDocument(htmlContent);

            // Configure image save options
            var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Bmp);
            // Set background color (supported property)
            options.BackgroundColor = Color.Beige;

            // Define output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.bmp");

            // Convert HTML to image
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            // Example pixel to millimeter conversion
            double pixels = 400.0;
            const double ppi = 96.0;
            double millimeters = (pixels / ppi) * 25.4;
            Console.WriteLine($"Pixel: {{ {pixels} }} = {{ {millimeters:F2} }} mm");

            Console.WriteLine($"Conversion completed. Image saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}