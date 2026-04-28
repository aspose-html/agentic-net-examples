// Set PdfSaveOptions.Title and Author before conversion to embed custom metadata into the flattened PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // HTML content to be converted
            string html = "<html><body><h1>Hello World</h1></body></html>";
            // Base URL for resolving relative resources (if any)
            string baseUrl = "file:///";

            // Load HTML into an Aspose.HTML document
            HTMLDocument document = new HTMLDocument(html, baseUrl);

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Set custom PDF metadata
            options.DocumentInfo.Title = "Sample PDF Title";
            options.DocumentInfo.Author = "John Doe";

            // Output PDF file path
            string outputPath = "output.pdf";

            // Perform conversion
            Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}