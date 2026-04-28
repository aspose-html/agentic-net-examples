// Configure PdfRenderingOptions to set both top and bottom margins to 0.25 inches for compact pages.

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

            // left, top, right, bottom margins (in inches)
            Margin margin = new Margin(
                Length.FromInches(0),
                Length.FromInches(0.25),
                Length.FromInches(0),
                Length.FromInches(0.25));

            // A4 page size in points (approximately 595x842)
            Size size = new Size(595, 842);

            Page page = new Page(size, margin);
            options.PageSetup.AnyPage = page;

            PdfDevice device = new PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}