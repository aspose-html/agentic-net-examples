// Create a PdfDevice with custom page size of 5 by 7 inches for small‑format PDF generation.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body><h1>Hello, PDF!</h1></body></html>");

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(360, 504));

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);

            Aspose.Html.Rendering.HtmlRenderer renderer = new Aspose.Html.Rendering.HtmlRenderer();
            renderer.Render(device, document);
            renderer.Dispose();

            device.Dispose();
            document.Dispose();

            Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}