// Set Accept-Language header in RequestMessage to request localized content.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class AcceptLanguageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["Accept-Language"] = "en-US,en;q=0.9";
        Next(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new AcceptLanguageHandler());

            string url = "https://example.com";
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions();
                string outputPath = "output.pdf";
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("Conversion completed successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}