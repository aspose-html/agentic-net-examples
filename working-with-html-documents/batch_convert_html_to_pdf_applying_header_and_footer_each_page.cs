// Batch convert HTML to PDF, applying a header and footer on each page of the output.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML contents
            string html1 = "<html><body><h1>Document 1</h1><p>This is the first document.</p></body></html>";
            string html2 = "<html><body><h1>Document 2</h1><p>This is the second document.</p></body></html>";
            string html3 = "<html><body><h1>Document 3</h1><p>This is the third document.</p></body></html>";

            // Base URL (can be any valid URL)
            string baseUrl = "http://example.com";

            // Create HTMLDocument instances
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUrl);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUrl);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUrl);

            // Prepare PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            // Set page size (A4: 595x842 points)
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            // Set background color
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "CombinedDocuments.pdf");

            // Create PDF device
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Render all three documents into a single PDF
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document1, document2, document3);

            Console.WriteLine($"PDF successfully created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}