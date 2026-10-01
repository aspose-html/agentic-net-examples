// Convert 750 pixel height to points and apply the value to set line spacing in PDF text.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 750;
            double heightPoints = heightPixels * 72.0 / 96.0;
            Console.WriteLine($"Height in points: {heightPoints:F2}");

            string htmlContent = $"<html><body><p style='line-height:{heightPoints:F2}pt;'>Sample text with custom line spacing.</p></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            string outputPath = "output.pdf";
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}