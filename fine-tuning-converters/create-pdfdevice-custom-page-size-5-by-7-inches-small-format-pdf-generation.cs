// Create a PdfDevice with custom page size of 5 by 7 inches for small‑format PDF generation.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<html><body><h1>Small Format PDF</h1></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF rendering options with custom page size (5x7 inches = 360x504 points)
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(360, 504));

            // Define output PDF path
            string savePath = Path.Combine(Environment.CurrentDirectory, "small_format.pdf");

            // Create PDF device
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            // Render HTML to PDF
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document);

            // Dispose resources
            renderer.Dispose();
            device.Dispose();
            document.Dispose();

            Console.WriteLine($"PDF generated successfully at: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}