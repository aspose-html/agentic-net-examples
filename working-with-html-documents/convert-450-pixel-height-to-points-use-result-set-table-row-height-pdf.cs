// Convert 450 pixel height to points and use the result to set table row height in PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 450;
            double heightPoints = heightPixels * 72.0 / 96.0;
            Console.WriteLine($"Height in points: {heightPoints:F2}");

            string html = $"<html><body><table border='1'><tr style='height:{heightPoints}pt;'><td>Row with height {heightPoints:F2}pt</td></tr></table></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, "about:blank");

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}