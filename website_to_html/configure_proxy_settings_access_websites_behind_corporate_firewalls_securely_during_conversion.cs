// Configure proxy settings to access websites behind corporate firewalls securely during conversion.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            var proxy = new WebProxy("http://proxy.mycompany.com:8080");
            WebRequest.DefaultWebProxy = proxy;

            string url = "https://example.com";
            string outputPath = "output.pdf";

            Configuration configuration = new Configuration();

            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}