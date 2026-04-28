// Apply a custom 0.2‑inch left margin to PDF output by setting PdfRenderingOptions.MarginLeft.

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

            // Define margins: left 0.2 inch, others 0 inch
            Margin margin = new Margin(
                Aspose.Html.Drawing.Length.FromInches(0.2),
                Aspose.Html.Drawing.Length.FromInches(0),
                Aspose.Html.Drawing.Length.FromInches(0),
                Aspose.Html.Drawing.Length.FromInches(0)
            );

            // Define page size (A4 in points)
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