// Use HtmlRenderer.RenderToPdf with custom margins derived from pixel‑to‑inch conversions for the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            // Base URI for inline HTML
            string baseUri = "about:blank";

            // Create HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri))
            {
                // Define margins in pixels
                int leftPixels = 48;   // 0.5 inch
                int topPixels = 72;    // 0.75 inch
                int rightPixels = 48;  // 0.5 inch
                int bottomPixels = 72; // 0.75 inch

                // Convert pixels to inches (96 DPI)
                double leftInches = leftPixels / 96.0;
                double topInches = topPixels / 96.0;
                double rightInches = rightPixels / 96.0;
                double bottomInches = bottomPixels / 96.0;

                // Create margin object
                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(topInches),
                    Aspose.Html.Drawing.Length.FromInches(rightInches),
                    Aspose.Html.Drawing.Length.FromInches(bottomInches),
                    Aspose.Html.Drawing.Length.FromInches(leftInches));

                // Set up PDF rendering options with custom page size and margins
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromInches(8),
                    Aspose.Html.Drawing.Length.FromInches(11));
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize, margin);
                options.PageSetup.AnyPage = page;

                // Output PDF path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

                // Render HTML to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF successfully created at: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}