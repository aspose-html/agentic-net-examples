// Merge three HTML files into a single PDF by invoking HtmlRenderer.RenderTo sequentially on the same PdfDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h1>Second Document</h1></body></html>";
            string html3 = "<html><body><h1>Third Document</h1></body></html>";
            string baseUri = "about:blank";
            string outputPath = "merged.pdf";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);

            document1.RenderTo(device);
            document2.RenderTo(device);
            document3.RenderTo(device);

            device.Dispose();

            Console.WriteLine("PDF merged successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}