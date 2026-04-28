// Use HtmlRenderer.RenderTo with a PdfDevice and shared RenderingOptions to apply common settings across multiple conversions.

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
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h2>Second Document</h2></body></html>";
            string html3 = "<html><body><p>Third Document</p></body></html>";
            string baseUri = "http://example.com";

            HTMLDocument document1 = new HTMLDocument(html1, baseUri);
            HTMLDocument document2 = new HTMLDocument(html2, baseUri);
            HTMLDocument document3 = new HTMLDocument(html3, baseUri);

            HtmlRenderer renderer = new HtmlRenderer();

            string savePath = "merged.pdf";

            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(400, 100));
            options.BackgroundColor = System.Drawing.Color.LightGray;

            PdfDevice device = new PdfDevice(options, savePath);

            renderer.Render(device, document1, document2, document3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}