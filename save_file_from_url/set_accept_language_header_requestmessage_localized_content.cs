// Set Accept-Language header in RequestMessage to request localized content.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Configuration configuration = new Configuration();

            // Get network service and add custom handler
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new AcceptLanguageHandler());

            // Load HTML document with the configuration
            string url = "https://example.com";
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Convert to PDF (demonstration of processing)
                PdfSaveOptions options = new PdfSaveOptions();
                Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    // Custom handler to set Accept-Language header
    class AcceptLanguageHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Headers["Accept-Language"] = "en-US";
            Next(context);
        }
    }
}