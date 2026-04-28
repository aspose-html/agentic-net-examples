// Set PdfSaveOptions.CompressionLevel to balance file size and quality when flattening PDFs from HTML sources.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the resulting PDF will be saved
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options
            PdfSaveOptions options = new PdfSaveOptions();

            // Flatten form fields so they become static content
            options.FormFieldBehaviour = FormFieldBehaviour.Flattened;

            // Set JPEG quality to balance file size and image quality
            options.JpegQuality = 75;

            // Convert the HTML document to PDF with the specified options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}