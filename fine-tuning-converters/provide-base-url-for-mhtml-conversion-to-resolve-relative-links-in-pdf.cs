// Provide a base URL in HtmlLoadOptions when converting MHTML to ensure relative links resolve correctly in the PDF.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string baseUrl = "https://example.com/";
            string outputPath = "result.pdf";

            // Load the MHTML document with a base URL to resolve relative links
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, baseUrl);

            // PDF save options (default configuration)
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();

            // Convert the HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);

            Console.WriteLine("MHTML successfully converted to PDF.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}