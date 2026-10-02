// Render an HTML document to PDF while embedding a custom page header defined in CSS.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";
            string htmlContent = "<!DOCTYPE html><html><head></head><body><p>Hello, PDF!</p></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "@page { margin-top: 60pt; @top-center { content: \"Custom Header\"; font-size: 14pt; } }";

            document.Body.AppendChild(style);

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}