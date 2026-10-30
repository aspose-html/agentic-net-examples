// Convert pixel dimensions to millimeters and use them to define printable area in PDF layout.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

            // Convert to millimeters
            double widthMillimeters = (widthPixels / ppi) * 25.4;
            double heightMillimeters = (heightPixels / ppi) * 25.4;

            // Output conversion results
            System.Console.WriteLine($"Width: {widthMillimeters:F2} mm");
            System.Console.WriteLine($"Height: {heightMillimeters:F2} mm");

            // Prepare PDF rendering options with page size based on converted dimensions
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)),
                new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromMillimeters(0), // top
                    Aspose.Html.Drawing.Length.FromMillimeters(0), // right
                    Aspose.Html.Drawing.Length.FromMillimeters(0), // bottom
                    Aspose.Html.Drawing.Length.FromMillimeters(0)  // left
                )
            );

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello PDF</h1></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define output PDF path
            string outputPath = "output.pdf";

            // Render HTML to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}