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
            // Define pixel dimensions
            double widthPixels = 800.0;
            double heightPixels = 600.0;

            // Convert pixels to millimeters (96 PPI, 25.4 mm per inch)
            double widthMillimeters = widthPixels / 96.0 * 25.4;
            double heightMillimeters = heightPixels / 96.0 * 25.4;

            System.Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            System.Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Create a simple HTML file to render
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello, PDF!</p></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Define page size using the converted millimeter dimensions
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)
                )
            );

            // Set up PDF rendering options with the custom page size
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = page;

            // Render the document to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf"))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}