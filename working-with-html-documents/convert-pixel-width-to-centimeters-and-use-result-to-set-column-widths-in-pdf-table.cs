// Convert pixel width to centimeters and use the result to set column widths in a PDF table.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double columnWidthPixels = 200;
            double columnWidthCm = columnWidthPixels / 96.0 * 2.54;
            string html = $"<html><body><table border='1'><col style='width:{columnWidthCm:F2}cm;'><col><tr><td>Column 1</td><td>Column 2</td></tr></table></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank"))
            {
                Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
                string outputPath = "output.pdf";
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
                {
                    document.RenderTo(device);
                }
            }
            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}