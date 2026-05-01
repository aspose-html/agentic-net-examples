// Apply a custom DPI of 120 when saving HTML to PDF to balance file size and quality.

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

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Create PDF save options and set custom DPI
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 120; // DPI for horizontal axis
            options.VerticalResolution = 120;   // DPI for vertical axis

            // Convert HTML to PDF using the specified options
            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}