// Override default DPI to 600 when exporting large HTML tables to PDF for detailed printing.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

namespace AsposeHtmlPdfDpiExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the HTML file containing large tables
                string htmlPath = "large-table.html";

                // Desired output PDF file path
                string pdfPath = "large-table.pdf";

                // Create PDF save options and set DPI to 600
                var pdfOptions = new PdfSaveOptions();
                pdfOptions.HorizontalResolution = 600;
                pdfOptions.VerticalResolution = 600;

                // Convert HTML to PDF with the specified DPI
                Converter.ConvertHTML(htmlPath, pdfOptions, pdfPath);

                Console.WriteLine("PDF generated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}