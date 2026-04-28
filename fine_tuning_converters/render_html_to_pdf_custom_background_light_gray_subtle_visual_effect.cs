// Render HTML to PDF with custom background color set to light gray for subtle visual effect.

using System;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using System.Drawing;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string sourcePath = "input.html";

                // Path where the resulting PDF will be saved
                string outputPath = "output.pdf";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(sourcePath);

                // Configure PDF rendering options with a light gray background
                PdfRenderingOptions options = new PdfRenderingOptions()
                {
                    BackgroundColor = Color.LightGray
                };

                // Create a PDF device with the specified options and output path
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