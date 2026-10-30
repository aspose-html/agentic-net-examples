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
            // Define pixel dimensions
            double widthPixels = 800;
            double heightPixels = 600;
            const double ppi = 96.0;

            // Convert to inches
            double widthInches = widthPixels / ppi;
            double heightInches = heightPixels / ppi;

            // Convert to centimeters
            double widthCentimeters = widthInches * 2.54;
            double heightCentimeters = heightInches * 2.54;

            // Output conversion results
            Console.WriteLine($"Width: {widthPixels} px = {widthCentimeters:F2} cm");
            Console.WriteLine($"Height: {heightPixels} px = {heightCentimeters:F2} cm");

            // Prepare a simple HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, PDF!</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(htmlPath);

            // Configure PDF rendering options with page size based on converted dimensions
            var pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromCentimeters(widthCentimeters),
                    Aspose.Html.Drawing.Length.FromCentimeters(heightCentimeters)));

            // Render to PDF
            string outputPdf = "output.pdf";
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPdf))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated at: {Path.GetFullPath(outputPdf)}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}