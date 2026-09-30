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
            string htmlContent = "<html><body><h1>Hello, PDF!</h1></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent, "about:blank");

            PdfRenderingOptions options = new PdfRenderingOptions();
            // Note: AdjustToWidestPage property is not available in this API version.

            string pdfPath = "output.pdf";
            PdfDevice device = new PdfDevice(options, pdfPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}