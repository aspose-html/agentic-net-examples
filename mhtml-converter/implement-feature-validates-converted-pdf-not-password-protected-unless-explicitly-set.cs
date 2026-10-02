// Implement a feature that validates that the converted PDF is not password protected unless explicitly set.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Define output PDF path
            string outputPdfPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Prepare PDF save options without encryption (no password protection)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdfPath);

            // Validation: ensure the PDF is not password protected unless encryption was explicitly set
            bool encryptionExplicitlySet = false; // change to true if you set encryption on purpose

            if (options.Encryption != null && !encryptionExplicitlySet)
            {
                Console.WriteLine("Validation failed: PDF is password protected but encryption was not intended.");
            }
            else if (options.Encryption == null && encryptionExplicitlySet)
            {
                Console.WriteLine("Validation failed: PDF is not password protected despite explicit encryption request.");
            }
            else
            {
                Console.WriteLine("PDF conversion completed successfully. Password protection status matches expectations.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}