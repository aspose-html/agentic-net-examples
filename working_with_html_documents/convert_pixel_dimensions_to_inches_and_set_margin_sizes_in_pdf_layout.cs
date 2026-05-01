// Convert pixel dimensions to inches and use the values to set margin sizes in a PDF layout.

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
            // Input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Pixel margin values
            double leftPixels = 48;   // example: 0.5 inch
            double topPixels = 96;    // example: 1 inch
            double rightPixels = 48;
            double bottomPixels = 96;

            // Convert pixels to inches (96 pixels = 1 inch)
            double leftInches = leftPixels / 96.0;
            double topInches = topPixels / 96.0;
            double rightInches = rightPixels / 96.0;
            double bottomInches = bottomPixels / 96.0;

            // Create margin using inches
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

            // Load HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Render HTML to PDF using the device
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