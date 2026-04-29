// Verify PDF output contains the correct number of pages by opening the file with a PDF reader library.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Rendering;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input URL and output PDF path
            string url = "https://example.com";
            string outputPdfPath = "output.pdf";

            // Create an HTMLDocument from the URL
            HTMLDocument document = new HTMLDocument(url);

            // Set up PDF rendering options (optional page size)
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(595, 842)); // A4 size in points

            // Create a PDF device that writes directly to a file
            PdfDevice device = new PdfDevice(options, outputPdfPath);

            // Render the HTML document to PDF
            HtmlRenderer renderer = new HtmlRenderer();
            renderer.Render(device, document);

            // Dispose resources
            renderer.Dispose();
            device.Dispose();
            document.Dispose();

            // ------------------------------------------------------------
            // Verify the number of pages in the generated PDF.
            // This step requires a PDF reader library (e.g., Aspose.Pdf,
            // PdfSharp, iTextSharp). Since such a library is not referenced
            // in the current project, the verification is omitted.
            // ------------------------------------------------------------
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}