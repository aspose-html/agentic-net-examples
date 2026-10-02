// Calculate point size from pixel values to adjust font sizes dynamically in generated PDFs.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value for font size
            double pixelFontSize = 16.0;
            const double ppi = 96.0;

            // Convert pixels to points (1 point = 1/72 inch)
            double pointFontSize = pixelFontSize * 72.0 / ppi;

            // Output conversion results
            System.Console.WriteLine($"Pixel font size: {pixelFontSize} px");
            System.Console.WriteLine($"Converted point font size: {pointFontSize:F2} pt");

            // Prepare HTML content with calculated point size
            string htmlContent = $"<html><body><p style='font-size:{pointFontSize:F2}pt;'>Sample text with {pixelFontSize}px font size converted to points.</p></body></html>";

            // Configure Aspose.HTML (optional fonts lookup folder can be set here)
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration);

            // Define output PDF path
            string outputPath = "output.pdf";

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, new Aspose.Html.Saving.PdfSaveOptions(), outputPath);

            System.Console.WriteLine($"PDF generated successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}