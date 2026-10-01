// Configure proxy settings to access websites behind corporate firewalls securely during conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string url = "https://example.com";
            string outputPath = "output.pdf";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}