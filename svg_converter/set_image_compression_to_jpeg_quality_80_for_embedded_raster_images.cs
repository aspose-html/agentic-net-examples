// Set PdfSaveOptions image compression to JPEG with quality 80 for embedded raster images.

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
            // Load the HTML source document
            HTMLDocument document = new HTMLDocument("input.html");

            // Create PDF save options and set JPEG compression quality to 80
            PdfSaveOptions options = new PdfSaveOptions();
            options.JpegQuality = 80;

            // Convert the HTML document to PDF with the specified options
            Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}