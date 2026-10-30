// Create a PdfDevice with AdjustToWidestPage disabled to keep original page widths during conversion.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello PDF</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            // AdjustToWidestPage is not available in this API version; default behavior keeps original page widths.

            string pdfPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);

            document.RenderTo(device);
            Console.WriteLine("PDF conversion completed successfully. Output: " + pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error during PDF conversion: " + ex.Message);
        }
    }
}