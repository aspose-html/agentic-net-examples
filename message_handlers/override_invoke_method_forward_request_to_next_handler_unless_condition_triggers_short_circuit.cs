// Override Invoke method to forward request to next handler unless condition triggers short‑circuit.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageHandlers;
using Aspose.Html.Services;

class SkipHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Get the request URI as a string
        string uriText = context.Request.RequestUri.ToString();

        // If the URI contains the skip marker, stop processing the pipeline
        if (uriText.Contains("?skip=true"))
            return;

        // Otherwise forward the request to the next handler
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration and obtain the network service
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the custom short‑circuit handler
            network.MessageHandlers.Add(new SkipHandler());

            // Load a document using the configured pipeline
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Example operation: output the document title
                Console.WriteLine(document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}