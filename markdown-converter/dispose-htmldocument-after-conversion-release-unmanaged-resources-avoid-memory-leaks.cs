// Dispose the HTMLDocument after conversion to release unmanaged resources and avoid memory leaks.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string baseUrl = "about:blank";
            string outputPath = "output.pdf";

            var document = new Aspose.Html.HTMLDocument(html, baseUrl);
            var options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}