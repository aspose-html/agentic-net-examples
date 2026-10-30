// Configure PdfSaveOptions to embed a custom JavaScript action that opens a URL when the PDF is opened.

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
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Load HTML content into a document (base URI is required for relative resources)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Configure PDF save options
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            // Note: Embedding custom JavaScript actions on PDF open is not directly supported via PdfSaveOptions in this API version.

            // Output PDF file path
            string outputPath = "output.pdf";

            // Convert HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine("PDF successfully saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}