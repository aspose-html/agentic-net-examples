// Block external HTTP resources by adding a NetworkDisabledMessageHandler that permits file, about, and base64 protocols.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Obtain the network service from the configuration
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Register the custom handler that allows only file, about, and base64 protocols
            networkService.MessageHandlers.Add(new NetworkDisabledMessageHandler());

            // Load an HTML document from a local file using the configured network settings
            string htmlPath = "sample.html";
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Save the document to verify successful loading
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom network handler that permits file, about, and base64 schemes
class NetworkDisabledMessageHandler : MessageHandler
{
    public NetworkDisabledMessageHandler()
    {
        // Allow file protocol
        Filters.Add(new ProtocolMessageFilter("file"));
        // Allow about protocol
        Filters.Add(new ProtocolMessageFilter("about"));
        // Allow base64 protocol
        Filters.Add(new ProtocolMessageFilter("base64"));
    }

    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request
        Next(context);
    }
}