// Render HTML to PDF with AdjustToWidestPage enabled to automatically fit content on each page.

using System;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><h1>Hello, World!</h1><p>This is a sample HTML to PDF conversion.</p></body></html>";
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html);
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
                options.PageSetup.AdjustToWidestPage = true;
                string pdfPath = "output.pdf";
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
                document.RenderTo(device);
                Console.WriteLine("PDF generated successfully at " + pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}