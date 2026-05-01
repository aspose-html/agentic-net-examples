// Use HtmlRenderer.RenderToPdf with PdfSaveOptions to specify image compression level for the output.

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
            // Path to the source HTML file
            string htmlPath = "input.html";

            // Path where the resulting PDF will be saved
            string pdfPath = "output.pdf";

            // Load the HTML document from the file system
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options and configure image compression (JPEG quality)
            PdfSaveOptions options = new PdfSaveOptions();
            options.JpegQuality = 75; // Lower quality = higher compression

            // Convert the HTML document to PDF using the specified options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during conversion
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}