// Set custom page margins of 0.5 inches in PdfSaveOptions before converting a long HTML document to PDF.

using System;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Drawing;
using Aspose.Html.Converters;

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
                Length.FromInches(8.5),
                Length.FromInches(11));

            Margin pageMargin = new Margin(
                Length.FromInches(0.5),
                Length.FromInches(0.5),
                Length.FromInches(0.5),
                Length.FromInches(0.5));

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