// Apply a custom DPI of 120 when saving HTML to PDF to balance file size and quality.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello, PDF with custom DPI!</h1></body></html>";
            string baseUri = "about:blank";

            // Load HTML into a document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            // Configure PDF save options with custom DPI
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 120;
            options.VerticalResolution = 120;

            // Output PDF path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}