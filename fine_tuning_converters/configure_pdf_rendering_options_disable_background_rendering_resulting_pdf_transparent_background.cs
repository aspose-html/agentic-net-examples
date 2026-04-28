// Configure PdfRenderingOptions to disable background rendering, resulting in a PDF with transparent background.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using System.Drawing;

namespace PdfBackgroundExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Desired output PDF file path
                string outputPath = "output.pdf";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Configure PDF rendering options with a transparent background
                PdfRenderingOptions options = new PdfRenderingOptions()
                {
                    BackgroundColor = Color.Transparent
                };

                // Create a PDF device with the configured options
                PdfDevice device = new PdfDevice(options, outputPath);

                // Render the HTML document to PDF
                document.RenderTo(device);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}