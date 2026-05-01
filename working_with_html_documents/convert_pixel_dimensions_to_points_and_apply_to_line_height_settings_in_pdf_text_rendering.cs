// Convert pixel dimensions to points and apply them to line‑height settings in PDF text rendering.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            double lineHeightPixels = 24;
            double lineHeightPoints = lineHeightPixels * 72.0 / 96.0;

            string htmlContent = $"<html><body><p style='line-height:{lineHeightPoints:F2}pt;'>Sample text with custom line-height.</p></body></html>";

            string inputPath = Path.Combine(Path.GetTempPath(), "sample.html");
            File.WriteAllText(inputPath, htmlContent);

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath);
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}