// Write code to convert PDF and then split the PDF into individual pages using a PDF library.

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
            string htmlPath = "input.html";
            string pdfPath = "output.pdf";

            HTMLDocument document = new HTMLDocument(htmlPath);
            PdfSaveOptions options = new PdfSaveOptions();

            Converter.ConvertHTML(document, options, pdfPath);

            // Note: Splitting the resulting PDF into individual pages is not supported by Aspose.HTML.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}