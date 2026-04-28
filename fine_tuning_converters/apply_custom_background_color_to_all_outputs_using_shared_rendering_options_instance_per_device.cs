// Apply a custom background color to all outputs by passing a shared RenderingOptions instance to each device.

using System;
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
            // HTML sources
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h1>Second Document</h1></body></html>";
            string html3 = "<html><body><h1>Third Document</h1></body></html>";
            string baseUri = "http://example.com/";

            // Load HTML documents
            HTMLDocument document1 = new HTMLDocument(html1, baseUri);
            HTMLDocument document2 = new HTMLDocument(html2, baseUri);
            HTMLDocument document3 = new HTMLDocument(html3, baseUri);

            // Create renderer
            HtmlRenderer renderer = new HtmlRenderer();

            // Shared rendering options with custom background color
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(595, 842)); // A4 size
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            // Create PDF device using the shared options
            string outputPath = "output.pdf";
            PdfDevice device = new PdfDevice(options, outputPath);

            // Render all documents to the same PDF
            renderer.Render(device, document1, document2, document3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}