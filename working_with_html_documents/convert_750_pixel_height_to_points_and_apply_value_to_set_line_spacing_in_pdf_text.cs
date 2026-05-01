// Convert 750 pixel height to points and apply the value to set line spacing in PDF text.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Convert 750 pixels to points (1 point = 1/72 inch, 1 pixel = 1/96 inch)
            double heightPixels = 750;
            double heightPoints = heightPixels * 72.0 / 96.0;

            // Create an HTML document with a paragraph
            string htmlContent = "<html><body></body></html>";
            HTMLDocument document = new HTMLDocument(htmlContent);

            // Create a paragraph element and set its line-height using points
            var paragraph = (HTMLParagraphElement)document.CreateElement("p");
            paragraph.TextContent = "Sample text with custom line spacing.";
            paragraph.Style.LineHeight = $"{heightPoints:F2}pt";

            // Append the paragraph to the document body
            document.Body.AppendChild(paragraph);

            // Prepare PDF rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Render the HTML document to a PDF file
            using (PdfDevice device = new PdfDevice(options, "output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}