// Convert HTML to PDF while disabling background rendering to produce a transparent‑background document.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Path where the PDF will be saved
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Configure PDF rendering options with a transparent background
            PdfRenderingOptions options = new PdfRenderingOptions()
            {
                BackgroundColor = Color.Transparent
            };

            // Create a PDF device with the specified options and output path
            PdfDevice device = new PdfDevice(options, pdfPath);

            // Render the HTML document to the PDF device
            document.RenderTo(device);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}