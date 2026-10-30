// Configure proxy settings to access websites behind corporate firewalls securely during conversion.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Configure proxy for outgoing HTTP requests
            System.Net.WebRequest.DefaultWebProxy = new System.Net.WebProxy("http://proxy.example.com:8080");
            System.Net.WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultCredentials;

            string url = "https://example.com";
            string outputPath = "output.pdf";

            Aspose.Html.Url sourceUrl = new Aspose.Html.Url(url);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            Aspose.Html.Converters.Converter.ConvertHTML(sourceUrl, options, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}