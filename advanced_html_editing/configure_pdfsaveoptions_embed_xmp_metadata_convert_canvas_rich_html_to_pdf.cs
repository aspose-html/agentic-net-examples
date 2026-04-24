// Configure PdfSaveOptions to embed XMP metadata, then convert a canvas‑rich HTML document to PDF.

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
            // Path to the HTML file that contains canvas drawings
            string htmlPath = "input.html";

            // Desired output PDF file path
            string pdfPath = "output.pdf";

            // Load the HTML document (canvas‑rich)
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options.
            // XMP metadata embedding is not supported directly in Aspose.HTML,
            // so default options are used.
            PdfSaveOptions options = new PdfSaveOptions();

            // Convert the HTML document to PDF using the configured options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}