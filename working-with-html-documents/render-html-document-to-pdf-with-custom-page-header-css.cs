// Render an HTML document to PDF while embedding a custom page header defined in CSS.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";
            string htmlContent = "<!DOCTYPE html><html><head></head><body><header>Custom Header</header><div style='height:1000px;'>Content goes here...</div></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "header { position: fixed; top: 0; left: 0; right: 0; height: 50px; background: #f0f0f0; text-align: center; line-height: 50px; font-weight: bold; } @page { margin-top: 60px; }";
            document.Body.AppendChild(style);
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
            Console.WriteLine("PDF generated at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}