// Convert 450 pixel height to points and use the result to set table row height in PDF.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            double heightPixels = 450.0;
            double heightPoints = heightPixels * 72.0 / 96.0;
            Console.WriteLine($"Height in points: {heightPoints:F2}");

            string htmlContent = $"<html><body><table border='1'><tr style='height:{heightPoints}pt;'><td>Sample cell</td></tr></table></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            Aspose.Html.Rendering.Pdf.PdfRenderingOptions options = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            options.PageSetup.PageLayoutOptions = Aspose.Html.Rendering.PageLayoutOptions.FitToContentWidth | Aspose.Html.Rendering.PageLayoutOptions.FitToContentHeight;

            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(options, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}