// Configure PdfSaveOptions to set a custom PDF version number for compatibility with older readers.

using System;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output PDF file paths
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            // Create PDF save options (custom PDF version setting is not supported in Aspose.HTML)
            PdfSaveOptions pdfOptions = new PdfSaveOptions();

            // Convert HTML to PDF using the options
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}