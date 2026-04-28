// Set PdfRenderingOptions.MarginBottom to 0.3 inches for tighter bottom spacing in PDF documents.

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

            // Define margins: left, top, right = 1 inch; bottom = 0.3 inch
            Margin margin = new Margin(
                Length.FromInches(1.0),
                Length.FromInches(1.0),
                Length.FromInches(1.0),
                Length.FromInches(0.3)
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
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}