// Load an HTML file and render it to a PDF document using default DPI settings.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source HTML file
                string htmlPath = "input.html";

                // Path for the resulting PDF file
                string pdfPath = "output.pdf";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(htmlPath);

                // Create default PDF save options (default DPI will be used)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert HTML to PDF
                Converter.ConvertHTML(document, options, pdfPath);

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}