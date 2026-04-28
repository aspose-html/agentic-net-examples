// Provide a base URL to ConvertHTML to correctly resolve relative links and resources during PDF generation.

using System;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content that may contain relative links to CSS, images, etc.
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"styles.css\"></head><body><h1>Hello World</h1></body></html>";

            // Base URL used to resolve the relative resources in the HTML.
            string baseUri = "file:///C:/MyProject/Resources/";

            // PDF conversion options (default settings).
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Output PDF file path.
            string outputPath = "result.pdf";

            // Convert the HTML string to PDF using the base URI for resource resolution.
            Converter.ConvertHTML(htmlContent, baseUri, pdfOptions, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}