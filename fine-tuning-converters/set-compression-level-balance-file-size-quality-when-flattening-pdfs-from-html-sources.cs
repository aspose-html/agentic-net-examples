// Set PdfSaveOptions.CompressionLevel to balance file size and quality when flattening PDFs from HTML sources.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello, PDF!</h1><img src='https://via.placeholder.com/150' /></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions renderOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            renderOptions.JpegQuality = 80; // balance file size and quality

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(renderOptions, "output.pdf");
            document.RenderTo(device);

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}