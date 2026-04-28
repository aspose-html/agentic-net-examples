// Create a PdfDevice with AdjustToWidestPage disabled to keep original page widths during conversion.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            var document = new Aspose.Html.HTMLDocument("input.html");
            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AdjustToWidestPage = false;
            var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, "output.pdf");
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}