// Apply a custom 1‑inch top margin to PDF output by configuring PdfRenderingOptions.MarginTop before rendering.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfRenderingOptions options = new PdfRenderingOptions();

            Margin margin = new Margin(
                Length.FromInches(0),
                Length.FromInches(1),
                Length.FromInches(0),
                Length.FromInches(0)
            );

            Size size = new Size(595, 842);
            Page page = new Page(size, margin);
            options.PageSetup.AnyPage = page;

            PdfDevice device = new PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}