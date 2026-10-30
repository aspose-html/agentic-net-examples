// Apply a custom 600x800 pixel page size to PDF output by configuring PdfDevice.AnyPage before rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><h1>Hello, PDF!</h1></body></html>";
            var document = new Aspose.Html.HTMLDocument(html, new Aspose.Html.Url("about:blank"));

            var renderingOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            var anyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(600, 800));
            renderingOptions.PageSetup.AnyPage = anyPage;

            string outputPath = "output.pdf";
            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(renderingOptions, outputPath);

            var renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}