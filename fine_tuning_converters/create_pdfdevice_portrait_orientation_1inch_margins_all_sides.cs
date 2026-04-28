// Create a PdfDevice with custom page orientation set to Portrait and apply 1‑inch margins on all sides.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

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
                Length.FromInches(1),
                Length.FromInches(1),
                Length.FromInches(1),
                Length.FromInches(1));

            Size size = new Size(595, 842); // Portrait A4 size in points
            Page page = new Page(size, margin);
            options.PageSetup.AnyPage = page;

            PdfDevice device = new PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}