// Perform incremental conversion of large HTML files to PDF by processing sections with separate PdfDevice instances.

using System;
using Aspose.Html;
using Aspose.Html.Rendering;
using Aspose.Html.Rendering.Pdf;

namespace IncrementalHtmlToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define HTML sections to be converted
                string[] htmlSections = new string[]
                {
                    "<html><body><h1>Section 1</h1><p>Content of the first section.</p></body></html>",
                    "<html><body><h1>Section 2</h1><p>Content of the second section.</p></body></html>",
                    "<html><body><h1>Section 3</h1><p>Content of the third section.</p></body></html>"
                };

                // Initialize the renderer (can be reused)
                HtmlRenderer renderer = new HtmlRenderer();

                for (int i = 0; i < htmlSections.Length; i++)
                {
                    // Create an HTMLDocument for the current section
                    HTMLDocument document = new HTMLDocument(htmlSections[i], "");

                    // Define output PDF path for this section
                    string savePath = $"output_section_{i + 1}.pdf";

                    // Create a PdfDevice for the current section
                    PdfDevice device = new PdfDevice(savePath);

                    // Render the HTMLDocument to the PDF device
                    renderer.Render(device, document);
                }

                Console.WriteLine("Incremental conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}