// Define custom page size of A4 in ImageSaveOptions before converting HTML to PDF for standard documents.

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

            Size pageSize = new Size(Length.FromInches(8.27f), Length.FromInches(11.69f));
            Margin margin = new Margin(0, 0, 0, 0);
            Page page = new Page(pageSize, margin);
            options.PageSetup.AnyPage = page;

            Converter.ConvertHTML(document, options, pdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}