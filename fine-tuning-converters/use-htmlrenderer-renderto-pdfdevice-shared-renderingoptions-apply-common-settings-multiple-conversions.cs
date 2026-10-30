// Use HtmlRenderer.RenderTo with a PdfDevice and shared RenderingOptions to apply common settings across multiple conversions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html1 = "<html><body><h1>Document 1</h1></body></html>";
            string html2 = "<html><body><h1>Document 2</h1></body></html>";
            string html3 = "<html><body><h1>Document 3</h1></body></html>";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(html1, "about:blank");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(html2, "about:blank");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(html3, "about:blank");

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            string outputPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document1, document2, document3);

            System.Console.WriteLine("PDF generated successfully at " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}