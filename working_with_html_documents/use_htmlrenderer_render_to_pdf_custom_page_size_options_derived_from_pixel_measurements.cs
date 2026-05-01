// Use HtmlRenderer.RenderToPdf with custom page size options derived from pixel measurements.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Input HTML file path
            string htmlPath = "input.html";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure PDF rendering options with a custom page size (pixels)
            PdfRenderingOptions options = new PdfRenderingOptions();
            options.PageSetup.AnyPage = new Page(new Size(800, 600)); // width=800px, height=600px

            // Create a PDF device using the options and output path
            PdfDevice device = new PdfDevice(options, outputPath);

            // Render the HTML document to PDF
            HtmlRenderer renderer = new HtmlRenderer();
            renderer.Render(device, document);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}