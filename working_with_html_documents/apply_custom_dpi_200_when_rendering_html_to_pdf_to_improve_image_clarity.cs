// Apply a custom DPI of 200 when rendering HTML to PDF to improve image clarity.

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
            // Path to the source HTML file
            string htmlPath = "input.html";
            // Desired output PDF file path
            string pdfPath = "output.pdf";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options and set custom DPI
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 200; // 200 DPI horizontal
            options.VerticalResolution = 200;   // 200 DPI vertical

            // Convert HTML to PDF with the specified options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}