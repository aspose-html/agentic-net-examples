// Set custom User-Agent header in RequestMessage before downloading.

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
            // Create a configuration instance
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain the network service from the configuration
            INetworkService network = configuration.GetService<INetworkService>();

            // Register a custom message handler that sets the User-Agent header
            network.MessageHandlers.Add(new CustomUserAgentHandler());

            // Load the HTML document using the configuration (the custom header will be applied)
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Set PDF conversion options
                PdfSaveOptions options = new PdfSaveOptions();

                // Convert the HTML document to PDF
                Converter.ConvertHTML(document, options, "output.pdf");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to inject a User-Agent header into outgoing requests
class CustomUserAgentHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Headers["User-Agent"] = "MyCustomUserAgent/1.0";
        Next(context);
    }
}