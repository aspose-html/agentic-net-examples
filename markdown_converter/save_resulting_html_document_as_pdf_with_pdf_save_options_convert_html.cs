// Save the resulting HTMLDocument as a PDF file by providing PdfSaveOptions to ConvertHTML.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Source HTML document (URL or local file path)
                string sourceUrl = "https://example.com/sample.html";
                // Destination PDF file path
                string outputPath = "output.pdf";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(sourceUrl);

                // Create PDF save options (default settings)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF
                Converter.ConvertHTML(document, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}