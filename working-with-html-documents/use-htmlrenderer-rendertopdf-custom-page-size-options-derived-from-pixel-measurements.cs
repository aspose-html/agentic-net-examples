// Use HtmlRenderer.RenderToPdf with custom page size options derived from pixel measurements.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(800, 600));
            options.BackgroundColor = System.Drawing.Color.AliceBlue;

            string outputPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            document.RenderTo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}