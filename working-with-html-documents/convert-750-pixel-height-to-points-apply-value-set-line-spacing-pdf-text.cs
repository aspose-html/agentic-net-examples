// Convert 750 pixel height to points and apply the value to set line spacing in PDF text.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 750 pixels to points
            double heightPixels = 750;
            double heightPoints = heightPixels * 72.0 / 96.0;

            // Prepare HTML with custom line spacing (line-height) in points
            string htmlContent = $"<html><body><p style=\"line-height:{heightPoints:F2}pt;\">This paragraph uses a line spacing of {heightPoints:F2} points, which corresponds to 750 pixels.</p></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set up PDF rendering options (default page size)
            Aspose.Html.Rendering.Pdf.PdfRenderingOptions pdfOptions = new Aspose.Html.Rendering.Pdf.PdfRenderingOptions();

            // Define output PDF path
            string outputPath = "output.pdf";

            // Render HTML to PDF
            using (Aspose.Html.Rendering.Pdf.PdfDevice pdfDevice = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfOptions, outputPath))
            {
                document.RenderTo(pdfDevice);
            }

            Console.WriteLine($"PDF generated successfully at '{outputPath}'.");
            Console.WriteLine($"Height in points used for line spacing: {heightPoints:F2} pt");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}