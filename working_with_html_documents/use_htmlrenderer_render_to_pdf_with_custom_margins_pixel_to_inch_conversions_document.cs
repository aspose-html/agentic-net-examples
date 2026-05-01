// Use HtmlRenderer.RenderToPdf with custom margins derived from pixel‑to‑inch conversions for the document.

using System;
using Aspose.Html;
using Aspose.Html.Drawing;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to input HTML and output PDF
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Define margins in pixels
            double leftPixels = 50;
            double topPixels = 50;
            double rightPixels = 50;
            double bottomPixels = 50;

            // Convert pixel values to inches (96 DPI)
            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            // Create a Margin object using inch values
            Margin margin = new Margin(
                Length.FromInches(topInches),
                Length.FromInches(rightInches),
                Length.FromInches(bottomInches),
                Length.FromInches(leftInches));

            // Set up PDF rendering options with page size and margins
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(
                new Size(Length.FromInches(8), Length.FromInches(11)),
                margin);

            // Render the HTML document to PDF using the configured device
            using (PdfDevice device = new PdfDevice(options, pdfPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}