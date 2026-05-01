// Generate a PDF report that includes rendered HTML sections with custom DPI for high quality.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using System.Drawing;

namespace HtmlToPdfReport
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input HTML file and output PDF file paths
                string htmlPath = "report.html";
                string pdfPath = "report.pdf";

                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Create PDF save options with custom DPI and quality settings
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                options.HorizontalResolution = 600;
                options.VerticalResolution = 600;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;
                options.JpegQuality = 95;

                // Define page size and margins (optional)
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(800, 600),
                    new Aspose.Html.Drawing.Margin(20, 10, 10, 10));
                options.PageSetup.AnyPage = page;

                // Convert the HTML document to a high‑quality PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}