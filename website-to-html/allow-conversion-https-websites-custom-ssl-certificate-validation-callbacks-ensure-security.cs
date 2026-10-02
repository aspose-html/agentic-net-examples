// Allow conversion of HTTPS websites with custom SSL certificate validation callbacks to ensure security.

using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main()
    {
        try
        {
            // Custom SSL certificate validation: accept only if there are no SSL errors.
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return sslPolicyErrors == System.Net.Security.SslPolicyErrors.None;
            };

            string url = "https://example.com";
            string outputPath = "output.pdf";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}