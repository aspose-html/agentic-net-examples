// Convert 640 pixel height to inches and use the value to set image height in a PDF report.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            double pixelCount = 640;
            const double ppi = 96.0;
            double inches = pixelCount / ppi;
            Console.WriteLine($"Pixel count: {pixelCount} => Inches: {inches:F4}");

            // Create a Length instance from inches (demonstration purpose)
            Aspose.Html.Drawing.Length heightLength = Aspose.Html.Drawing.Length.FromInches(inches);
            Console.WriteLine($"Length object created: {heightLength}");

            // Build HTML content with an image whose height is set using the calculated inches
            string htmlContent = $"<html><body><img src='https://via.placeholder.com/300' style='height:{inches}in;'></body></html>";

            // Load HTML document (use two‑argument constructor as required)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define output PDF path
            string outputPath = "report.pdf";

            // Convert HTML to PDF
            var pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine($"PDF report generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}