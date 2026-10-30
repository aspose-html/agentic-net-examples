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
            string htmlContent = "<html><body><h1>Hello World</h1><img src='https://via.placeholder.com/150'></body></html>";
            string baseUri = "about:blank";
            HTMLDocument document = new HTMLDocument(htmlContent, baseUri);
            PdfSaveOptions options = new PdfSaveOptions();
            options.HorizontalResolution = 200;
            options.VerticalResolution = 200;
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            Console.WriteLine("PDF saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}