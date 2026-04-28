// Render HTML to PDF with AdjustToWidestPage enabled to automatically fit content on each page.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML content to be rendered
                string htmlContent = "<html><body><h1>Hello World</h1><p>This is a sample HTML.</p></body></html>";
                // Base URI for the HTML document (can be empty if not needed)
                string baseUri = "file:///";

                // Load HTML content into an HTMLDocument
                HTMLDocument document = new HTMLDocument(htmlContent, baseUri);

                // Create PDF rendering options
                PdfRenderingOptions options = new PdfRenderingOptions();

                // Define an initial page size (will be adjusted automatically)
                options.PageSetup.AnyPage = new Page(new Size(800, 600));

                // Enable automatic adjustment to the widest page
                options.PageSetup.AdjustToWidestPage = true;

                // Create PDF device with the configured options and output file path
                string outputPath = "output.pdf";
                PdfDevice device = new PdfDevice(options, outputPath);

                // Render the HTML document to the PDF device
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}