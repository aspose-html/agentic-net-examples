// Add a custom user‑agent string to outgoing requests via a header‑injection handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class CustomUserAgentHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Inject custom User-Agent header
        context.Request.Headers["User-Agent"] = "MyApp/1.0";
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Configuration configuration = new Configuration();

            // Get network service and add the custom handler
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            // Load HTML document using the configuration
            using (HTMLDocument document = new HTMLDocument("input.html", "", configuration))
            {
                // Set PDF conversion options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert HTML to PDF with the custom User-Agent applied to all requests
                Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}