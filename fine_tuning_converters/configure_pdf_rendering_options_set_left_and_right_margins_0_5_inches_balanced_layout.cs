// Configure PdfRenderingOptions to set both left and right margins to 0.5 inches for balanced layout.

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
            // Input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create rendering options
            PdfRenderingOptions options = new PdfRenderingOptions();

            // Define margins: top, right, bottom, left (in inches)
            // Left and right margins set to 0.5 inches, top and bottom set to 0
            Margin margin = new Margin(
                Length.FromInches(0),      // Top
                Length.FromInches(0.5),    // Right
                Length.FromInches(0),      // Bottom
                Length.FromInches(0.5)     // Left
            );

            // Define page size (A4 in points: 595 x 842)
            Size size = new Size(595, 842);

            // Create a page with the specified size and margins
            Page page = new Page(size, margin);

            // Apply the page configuration to all pages
            options.PageSetup.AnyPage = page;

            // Create PDF device with the options and output path
            PdfDevice device = new PdfDevice(options, pdfPath);

            // Render the HTML document to PDF
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}