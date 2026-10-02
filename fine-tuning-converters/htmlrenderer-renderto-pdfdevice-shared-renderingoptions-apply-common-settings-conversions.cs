// Use HtmlRenderer.RenderTo with a PdfDevice and shared RenderingOptions to apply common settings across multiple conversions.

using System;
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

            // Create HTMLDocument instances (inline content with a dummy base URI)
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "about:blank");

            // Shared PDF rendering options
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842)); // A4 size
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // PDF device with shared options
            string outputPath = "combined.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            // Renderer
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            // Render multiple documents using the same device and options
            renderer.Render(device, document1, document2, document3);

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}