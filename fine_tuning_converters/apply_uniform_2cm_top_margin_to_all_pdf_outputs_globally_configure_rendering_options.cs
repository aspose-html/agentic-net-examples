// Apply a uniform 2‑centimeter top margin to all PDF outputs by configuring PdfRenderingOptions globally.

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

            // 2 cm = 0.7874015748 inches
            Margin margin = new Margin(
                Length.FromInches(0.7874015748), // top
                Length.FromInches(0),            // right
                Length.FromInches(0),            // bottom
                Length.FromInches(0)             // left
            );

            // A4 size in points (approx 595x842)
            Size size = new Size(595, 842);
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