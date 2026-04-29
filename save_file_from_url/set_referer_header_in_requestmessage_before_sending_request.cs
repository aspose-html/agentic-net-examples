// Set the Referer header in RequestMessage before sending the request.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();

            var request = new Aspose.Html.Net.RequestMessage("https://example.com");
            request.Headers["Referer"] = "https://referrer.com";

            using var document = new Aspose.Html.HTMLDocument(request, configuration);

            var options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, "output.pdf");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}