// Convert pixel dimensions to points and apply them to line‑height settings in PDF text rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double lineHeightPixels = 24.0;
            double lineHeightPoints = lineHeightPixels * 72.0 / 96.0;
            Console.WriteLine($"Line height: {lineHeightPoints:F2} points");

            string htmlContent = $"<html><body><p style='font-size:12pt; line-height:{lineHeightPoints:F2}pt;'>Sample text with custom line height.</p></body></html>";
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            string outputPath = "output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}