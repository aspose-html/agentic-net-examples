// Design a short‑circuit handler that returns immediate response when specific query parameter is present.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Retrieve the network service from the configuration
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the short‑circuit handler
            network.MessageHandlers.Add(new SkipHandler());

            // Load an HTML document using the custom configuration
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Document processing can be performed here
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Handler that aborts the request pipeline when the query contains "skip=true"
class SkipHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        string uriText = context.Request.RequestUri.ToString();
        if (uriText.Contains("skip=true"))
            return; // Short‑circuit: do not forward to the next handler
        Next(context);
    }
}