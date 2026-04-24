// Generate a PDF from multiple HTML strings by sequentially rendering each document to the same PdfDevice.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // HTML snippets to be merged
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h1>Second Document</h1></body></html>";
            string html3 = "<html><body><h1>Third Document</h1></body></html>";

            // Base URI required by HTMLDocument constructor
            string baseUri = "about:blank";

            // Create HTMLDocument instances from the strings
            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            // Initialize the renderer
            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            // Define output PDF file path and create a PdfDevice
            string outputPath = "merged.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);

            // Render each document sequentially to the same PdfDevice
            renderer.Render(device, document1);
            renderer.Render(device, document2);
            renderer.Render(device, document3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}