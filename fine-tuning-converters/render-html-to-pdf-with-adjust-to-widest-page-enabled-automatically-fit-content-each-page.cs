// Render HTML to PDF with AdjustToWidestPage enabled to automatically fit content on each page.

using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, PDF!</h1><p>This is a sample HTML rendered to PDF with AdjustToWidestPage.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            Aspose.Html.Drawing.Size pageSize = new Aspose.Html.Drawing.Size(595, 842);
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(pageSize);
            options.PageSetup.AnyPage = page;
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