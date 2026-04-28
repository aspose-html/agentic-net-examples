// Configure PdfRenderingOptions to set both top and bottom margins to 2 centimeters for uniform spacing.

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

            double cmToInch = 2.0 / 2.54;
            Margin margin = new Margin(
                Length.FromInches(cmToInch),
                Length.FromInches(cmToInch),
                Length.FromInches(cmToInch),
                Length.FromInches(cmToInch)
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