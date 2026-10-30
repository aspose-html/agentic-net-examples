// Generate PDF files from HTML templates, injecting dynamic data and using default unit conversion.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define HTML template with placeholder
            string template = "<html><body><h1>Hello, {{name}}!</h1></body></html>";
            // Inject dynamic data
            string htmlContent = template.Replace("{{name}}", "John Doe");
            // Base URI for the inline HTML
            string baseUri = "about:blank";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Set PDF save options (default settings)
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine($"PDF successfully generated at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred during PDF generation:");
            Console.WriteLine(ex.Message);
        }
    }
}