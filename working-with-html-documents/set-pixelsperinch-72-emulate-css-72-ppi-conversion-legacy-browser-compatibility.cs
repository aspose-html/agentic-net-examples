// Set PixelsPerInch to 72 to emulate CSS 72 PPI conversion for legacy browser compatibility.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.HorizontalResolution = 72;
            options.VerticalResolution = 72;
            string outputPath = "output.pdf";
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}