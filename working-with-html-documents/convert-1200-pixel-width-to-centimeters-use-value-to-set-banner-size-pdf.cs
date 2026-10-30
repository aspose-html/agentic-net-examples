// Convert 1200 pixel width to centimeters and use the value to set banner size in PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel dimensions
            double widthPixels = 1200;
            const double ppi = 96.0;

            // Convert to centimeters
            double widthInches = widthPixels / ppi;
            double widthCentimeters = widthInches * 2.54;

            // Create simple HTML with a banner of the calculated width
            string htmlContent = $"<html><body><div style='width:{widthCentimeters:F2}cm;height:5cm;background-color:#4CAF50;'>Banner</div></body></html>";

            // Load HTML document from string (use two‑argument constructor)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define page margins (1 cm on each side)
            var margin = new Aspose.Html.Drawing.Margin(
                Aspose.Html.Drawing.Length.FromCentimeters(1),
                Aspose.Html.Drawing.Length.FromCentimeters(1),
                Aspose.Html.Drawing.Length.FromCentimeters(1),
                Aspose.Html.Drawing.Length.FromCentimeters(1));

            // Set up PDF rendering options with page size matching the banner width
            var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromCentimeters(widthCentimeters),
                    Aspose.Html.Drawing.Length.FromCentimeters(5)), // banner height
                margin);

            // Render to PDF file
            string outputPath = "banner.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"Width in centimeters: {widthCentimeters:F2} cm");
            Console.WriteLine($"PDF saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}