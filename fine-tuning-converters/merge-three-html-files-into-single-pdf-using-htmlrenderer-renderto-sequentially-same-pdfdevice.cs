// Merge three HTML files into a single PDF by invoking HtmlRenderer.RenderTo sequentially on the same PdfDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>First Document</h1><p>This is the first HTML content.</p></body></html>";
            string html2 = "<html><body><h1>Second Document</h1><p>This is the second HTML content.</p></body></html>";
            string html3 = "<html><body><h1>Third Document</h1><p>This is the third HTML content.</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, baseUri);
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, baseUri);
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, baseUri);

            string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "merged.pdf");
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);

            document1.RenderTo(device);
            document2.RenderTo(device);
            document3.RenderTo(device);

            Console.WriteLine("PDF merged successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}