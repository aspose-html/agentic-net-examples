// Create a document, embed a base64‑encoded image, and export to PDF ensuring image renders.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base64-encoded 1x1 PNG image
            string base64Image = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=";
            // HTML content with embedded image
            string htmlContent = "<html><body><h1>Embedded Image Example</h1>" +
                                 "<img src='data:image/png;base64," + base64Image + "' alt='Sample Image'/>" +
                                 "</body></html>";

            // Create HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Set PDF save options (default options are sufficient)
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Output PDF file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");

            // Convert HTML document to PDF
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF successfully created at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}