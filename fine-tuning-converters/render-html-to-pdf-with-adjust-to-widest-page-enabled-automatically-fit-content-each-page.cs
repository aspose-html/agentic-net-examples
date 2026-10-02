// Render HTML to PDF with AdjustToWidestPage enabled to automatically fit content on each page.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><h1>Hello, PDF!</h1><p>This is a sample.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));
            options.PageSetup.AdjustToWidestPage = true;
            string outputPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
            document.RenderTo(device);
            Console.WriteLine("PDF generated successfully at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}