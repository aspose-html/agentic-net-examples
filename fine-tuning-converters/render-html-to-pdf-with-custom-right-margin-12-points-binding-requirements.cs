// Render HTML to PDF with custom right margin of 12 points to accommodate binding requirements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string pdfPath = "output.pdf";

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath,
                    "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            Aspose.Html.Drawing.Margin margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromInches(0.5), // left
                Aspose.Html.Drawing.Length.FromInches(0.5), // top
                Aspose.Html.Drawing.Length.FromInches(12.0 / 72.0), // right (12 points)
                Aspose.Html.Drawing.Length.FromInches(0.5)  // bottom
            );

            Aspose.Html.Drawing.Size size = new Aspose.Html.Drawing.Size(595, 842); // A4 size in points
            Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(size, margin);
            options.PageSetup.AnyPage = page;

            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, pdfPath);
            document.RenderTo(device);

            Console.WriteLine("PDF generated at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}