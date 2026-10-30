// Dispose the HTMLDocument after conversion to release unmanaged resources and avoid memory leaks.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<!DOCTYPE html><html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUri = "about:blank";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            string outputPath = "output.pdf";

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            document.Dispose();

            Console.WriteLine("Conversion completed. PDF saved to " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}