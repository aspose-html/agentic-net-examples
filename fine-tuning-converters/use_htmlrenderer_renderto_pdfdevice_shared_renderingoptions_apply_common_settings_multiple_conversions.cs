// Use HtmlRenderer.RenderTo with a PdfDevice and shared RenderingOptions to apply common settings across multiple conversions.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string code1 = "<html><body><h1>Document 1</h1></body></html>";
            string code2 = "<html><body><h1>Document 2</h1></body></html>";
            string code3 = "<html><body><h1>Document 3</h1></body></html>";

            Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument(code1, "");
            Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument(code2, "");
            Aspose.Html.HTMLDocument document3 = new Aspose.Html.HTMLDocument(code3, "");

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();

            string savePath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, savePath);

            renderer.Render(device, document1, document2, document3);

            System.Console.WriteLine("PDF generated at: " + savePath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}