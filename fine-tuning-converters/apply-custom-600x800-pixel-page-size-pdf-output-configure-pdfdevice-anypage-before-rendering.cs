// Apply a custom 600x800 pixel page size to PDF output by configuring PdfDevice.AnyPage before rendering.

using System;

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

            Aspose.Html.Drawing.Page anyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromPixels(600),
                    Aspose.Html.Drawing.Length.FromPixels(800)));

            options.PageSetup.AnyPage = anyPage;

            string outputPath = "output.pdf";

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            document.RenderTo(device);

            Console.WriteLine("PDF generated successfully at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}