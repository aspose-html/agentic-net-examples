// Merge three HTML files into a single PDF by invoking HtmlRenderer.RenderTo sequentially on the same PdfDevice.

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
            string html1 = "<html><body><h1>Document 1</h1></body></html>";
            string html2 = "<html><body><h1>Document 2</h1></body></html>";
            string html3 = "<html><body><h1>Document 3</h1></body></html>";
            string baseUri = "file:///";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            string outputPath = "merged.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);

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