// Generate a PDF from multiple HTML strings by sequentially rendering each document to the same PdfDevice.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>First Document</h1></body></html>";
            string html2 = "<html><body><h2>Second Document</h2></body></html>";
            string html3 = "<html><body><p>Third Document</p></body></html>";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "about:blank");

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            string outputPath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.BackgroundColor = System.Drawing.Color.White;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            renderer.Render(device, document1, document2, document3);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}