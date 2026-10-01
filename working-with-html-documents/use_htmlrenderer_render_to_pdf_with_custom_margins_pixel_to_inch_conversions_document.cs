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
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>";

            // Create HTMLDocument from the HTML string
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "."))
            {
                // Define margins in pixels
                double leftPixels = 72;   // 1 inch
                double topPixels = 72;
                double rightPixels = 72;
                double bottomPixels = 72;

                double leftInches = leftPixels / 96.0;
                double topInches = topPixels / 96.0;
                double rightInches = rightPixels / 96.0;
                double bottomInches = bottomPixels / 96.0;

                Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                    Aspose.Html.Drawing.Length.FromInches(topInches),
                    Aspose.Html.Drawing.Length.FromInches(rightInches),
                    Aspose.Html.Drawing.Length.FromInches(bottomInches),
                    Aspose.Html.Drawing.Length.FromInches(leftInches));

                // Set up PDF rendering options with page size and margins
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8),
                        Aspose.Html.Drawing.Length.FromInches(11)),
                    margin);

                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");

                // Render the document to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}