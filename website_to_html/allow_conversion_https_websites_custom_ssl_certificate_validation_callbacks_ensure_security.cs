// Allow conversion of HTTPS websites with custom SSL certificate validation callbacks to ensure security.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // URL of the HTTPS website to convert
            string url = "https://example.com";
            // Destination PDF file path
            string outputPath = "output.pdf";

            // Create a configuration instance (default settings)
            Configuration configuration = new Configuration();

            // Load the web page using the configuration
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Set PDF conversion options (default)
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the loaded HTML document to PDF
                Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}