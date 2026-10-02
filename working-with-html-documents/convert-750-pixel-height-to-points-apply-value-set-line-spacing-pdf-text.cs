// Convert 750 pixel height to points and apply the value to set line spacing in PDF text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 750;
            double heightPoints = heightPixels * 72.0 / 96.0;
            Console.WriteLine($"Height in points: {heightPoints:F2}");

            string htmlContent = $"<html><body><p style='line-height:{heightPoints:F2}pt;'>This paragraph has line spacing set to {heightPoints:F2} points.</p></body></html>";

            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            var options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            string outputPath = "output.pdf";

            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
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