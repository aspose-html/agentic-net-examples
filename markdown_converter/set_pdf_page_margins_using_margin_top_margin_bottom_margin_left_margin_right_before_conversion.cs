// Set PDF page margins using PdfSaveOptions.MarginTop, MarginBottom, MarginLeft, and MarginRight before conversion.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace HtmlToPdfWithMargins
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                HTMLDocument document = new HTMLDocument(htmlPath);
                PdfSaveOptions options = new PdfSaveOptions();

                // Define margins (top, right, bottom, left) in inches
                Margin margin = new Margin(1, 1, 1, 1);

                // Define page size (width, height) in pixels
                Size pageSize = new Size(595, 842); // Approximate A4 size

                // Create a page with the specified size and margins
                Page page = new Page(pageSize, margin);

                // Assign the page to the PDF save options
                options.PageSetup.AnyPage = page;

                // Convert HTML to PDF with the configured options
                Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}