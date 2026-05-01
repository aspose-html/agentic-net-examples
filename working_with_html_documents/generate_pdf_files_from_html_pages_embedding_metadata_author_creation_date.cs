// Generate PDF files from HTML pages, embedding metadata such as author and creation date.

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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            // Base URL for resolving relative resources (if any)
            string baseUrl = "http://example.com/";
            // Output PDF file path
            string outputPath = "output.pdf";

            // Load HTML into Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUrl);

            // Create PDF save options and set metadata
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.DocumentInfo.Title = "Sample PDF";
            options.DocumentInfo.Author = "John Doe";
            options.DocumentInfo.Subject = "Demo Conversion";
            options.DocumentInfo.Keywords = "Aspose,HTML,PDF";

            // Perform conversion and save PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Conversion failed: " + ex.Message);
        }
    }
}