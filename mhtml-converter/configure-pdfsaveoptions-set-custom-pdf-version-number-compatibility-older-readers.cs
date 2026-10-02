// Configure PdfSaveOptions to set a custom PDF version number for compatibility with older readers.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><h1>Hello PDF</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            // PdfSaveOptions does not expose a property to set PDF version directly.
            // The default version will be used for compatibility.

            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, pdfOptions, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}