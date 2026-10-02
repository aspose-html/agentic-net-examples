// Generate a PDF from multiple HTML strings by sequentially rendering each document to the same PdfDevice.

using System;
using System.IO;
using System.Drawing;
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
            // Sample HTML contents
            string html1 = "<html><body><h1>Document 1</h1><p>This is the first document.</p></body></html>";
            string html2 = "<html><body><h1>Document 2</h1><p>This is the second document.</p></body></html>";
            string html3 = "<html><body><h1>Document 3</h1><p>This is the third document.</p></body></html>";

            // Create HTMLDocument objects using inline content
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "about:blank");

            // Initialize renderer
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            // Set PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842)); // A4 size in points
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Output PDF path
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "CombinedOutput.pdf");

            // Create PDF device with options
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            // Render all documents sequentially into the same PDF
            renderer.Render(device, document1, document2, document3);

            Console.WriteLine($"PDF successfully created at: {savePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}