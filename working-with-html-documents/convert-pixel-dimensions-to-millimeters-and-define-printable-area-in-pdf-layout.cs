// Convert pixel dimensions to millimeters and use them to define printable area in PDF layout.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Predefined pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

            // Convert pixels to millimeters
            double widthMillimeters = (widthPixels / ppi) * 25.4;
            double heightMillimeters = (heightPixels / ppi) * 25.4;

            Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Create a simple HTML document from inline content
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1></body></html>";
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Define zero margins
                double leftInches = 0;
                double topInches = 0;
                double rightInches = 0;
                double bottomInches = 0;
                Margin margin = new Margin(
                    Length.FromInches(topInches),
                    Length.FromInches(rightInches),
                    Length.FromInches(bottomInches),
                    Length.FromInches(leftInches));

                // Set up PDF rendering options with page size based on millimeters
                PdfRenderingOptions options = new PdfRenderingOptions();
                options.PageSetup.AnyPage = new Page(
                    new Size(
                        Length.FromMillimeters(widthMillimeters),
                        Length.FromMillimeters(heightMillimeters)),
                    margin);

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                using (PdfDevice device = new PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}