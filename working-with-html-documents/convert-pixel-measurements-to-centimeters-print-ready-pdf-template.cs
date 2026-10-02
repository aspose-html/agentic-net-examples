// Convert pixel measurements to centimeters for use in a print‑ready PDF template.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Predefined pixel values
            double widthPixels = 800;
            double heightPixels = 600;

            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Convert to millimeters
            double widthMillimeters = widthCentimeters * 10.0;
            double heightMillimeters = heightCentimeters * 10.0;

            // Convert to points
            double widthPoints = widthInches * 72.0;
            double heightPoints = heightInches * 72.0;

            // Convert to picas
            double widthPicas = widthInches * 6.0;
            double heightPicas = heightInches * 6.0;

            // Output results
            System.Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm ({widthMillimeters:F2} mm, {widthInches:F2} in, {widthPoints:F2} pt, {widthPicas:F2} pc)");
            System.Console.WriteLine($"Height: {heightPixels} px = {heightCentimeters:F2} cm ({heightMillimeters:F2} mm, {heightInches:F2} in, {heightPoints:F2} pt, {heightPicas:F2} pc)");

            // Prepare a simple HTML content
            string htmlContent = "<!DOCTYPE html><html><head><meta charset='utf-8'></head><body><h1>Print‑Ready PDF</h1><p>Generated with Aspose.HTML.</p></body></html>";

            // Create HTML document from inline content
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up PDF rendering options with page size based on converted dimensions
            var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromMillimeters(widthMillimeters),
                    Aspose.Html.Drawing.Length.FromMillimeters(heightMillimeters)
                )
            );

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Render HTML to PDF
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine($"PDF generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}