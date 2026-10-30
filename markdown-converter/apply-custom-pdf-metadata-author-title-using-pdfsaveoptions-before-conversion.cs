// Apply custom PDF metadata such as author and title using PdfSaveOptions before conversion.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

namespace AsposeHtmlPdfMetadataExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare sample HTML content
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
                // Load HTML document from string (base URI is not required for this example)
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Configure PDF save options with custom metadata
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.DocumentInfo.Author = "John Doe";
                options.DocumentInfo.Title = "Sample PDF Document";

                // Define output PDF path
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

                // Convert HTML to PDF with the specified options
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine($"PDF successfully created at: {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}