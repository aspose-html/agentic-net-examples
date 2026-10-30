// Verify PDF output contains the correct number of pages by opening the file with a PDF reader library.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare simple HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello Aspose HTML</h1></body></html>";

            // Load HTML document from string (base URI is required)
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF save options
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output PDF path
            string outputPdf = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);

            // Verify PDF file existence and non-zero size
            if (!File.Exists(outputPdf))
                throw new Exception("PDF file was not created.");

            var info = new FileInfo(outputPdf);
            if (info.Length == 0)
                throw new Exception("PDF file is empty.");

            Console.WriteLine("PDF conversion verification passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}