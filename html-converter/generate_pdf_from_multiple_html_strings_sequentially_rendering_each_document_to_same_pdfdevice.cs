// Generate a PDF from multiple HTML strings by sequentially rendering each document to the same PdfDevice.

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>Document 1</h1><p>First page.</p></body></html>";
            string html2 = "<html><body><h1>Document 2</h1><p>Second page.</p></body></html>";
            string html3 = "<html><body><h1>Document 3</h1><p>Third page.</p></body></html>";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "");

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            string savePath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            renderer.Render(device, document1, document2, document3);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}