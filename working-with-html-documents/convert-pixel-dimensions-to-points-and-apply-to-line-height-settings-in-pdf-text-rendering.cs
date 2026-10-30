// Convert pixel dimensions to points and apply them to line‑height settings in PDF text rendering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define pixel value for line-height and convert to points
            double lineHeightPixels = 24.0;
            double lineHeightPoints = lineHeightPixels * 72.0 / 96.0;

            // Prepare simple HTML content
            string htmlContent = "<html><head></head><body></body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Create a paragraph element and set its line-height in points
            Aspose.Html.HTMLElement paragraph = (Aspose.Html.HTMLElement)document.CreateElement("p");
            paragraph.InnerHTML = "This paragraph uses a line-height converted from pixels to points.";
            paragraph.Style.LineHeight = $"{lineHeightPoints:F2}pt";

            // Append the paragraph to the document body
            document.Body.AppendChild(paragraph);

            // Render the document to PDF
            string outputPath = "output.pdf";
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine($"PDF generated successfully at '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}