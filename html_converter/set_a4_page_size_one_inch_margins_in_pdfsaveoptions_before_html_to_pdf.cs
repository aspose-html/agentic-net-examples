// Set A4 page size and one‑inch margins in PdfSaveOptions before converting HTML to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

namespace HtmlToPdfExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string htmlPath = "input.html";
                string pdfPath = "output.pdf";

                HTMLDocument document = new HTMLDocument(htmlPath);
                PdfSaveOptions options = new PdfSaveOptions();

                Size pageSize = new Size(
                    Length.FromInches(8.27),
                    Length.FromInches(11.69));

                Margin pageMargin = new Margin(
                    Length.FromInches(1),
                    Length.FromInches(1),
                    Length.FromInches(1),
                    Length.FromInches(1));

                Page page = new Page(pageSize, pageMargin);
                options.PageSetup.AnyPage = page;

                Converter.ConvertHTML(document, options, pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}