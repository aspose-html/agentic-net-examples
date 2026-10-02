// Create an HTML document, add a style block with media queries, and test rendering on different widths.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.pdf";

            string htmlContent = "<!DOCTYPE html><html><head></head><body><div class=\"box\">Responsive Box</div></body></html>";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.HTMLElement style = (Aspose.Html.HTMLElement)document.CreateElement("style");
            style.InnerHTML = "@media (max-width: 500px) { .box { background-color: red; } } @media (min-width: 501px) { .box { background-color: green; } } .box { width: 100%; height: 200px; }";

            document.Body.AppendChild(style);

            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}