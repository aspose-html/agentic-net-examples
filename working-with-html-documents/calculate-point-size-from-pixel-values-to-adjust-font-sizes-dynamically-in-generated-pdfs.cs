// Calculate point size from pixel values to adjust font sizes dynamically in generated PDFs.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value
            double widthPixels = 200.0;
            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;

            // Convert to points
            double widthPoints = widthInches * 72.0;

            // Output conversion results
            System.Console.WriteLine($"Width: {widthPixels} px = {widthInches:F4} in = {widthPoints:F2} pt");

            // Prepare HTML with dynamic font size in points
            string htmlContent = $"<html><head><style>p{{font-size:{widthPoints:F2}pt;}}</style></head><body><p>Sample text with dynamic font size.</p></body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF rendering options (optional)
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Render HTML to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath))
            {
                document.RenderTo(pdfDevice);
            }

            System.Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}