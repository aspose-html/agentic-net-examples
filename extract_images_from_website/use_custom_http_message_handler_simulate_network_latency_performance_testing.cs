// Use custom HttpMessageHandler to simulate network latency during performance testing.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class LatencyMessageHandler : MessageHandler
{
    // Simulate network latency before forwarding the request.
    public override void Invoke(INetworkOperationContext context)
    {
        // Introduce a fixed delay (e.g., 500 ms) to mimic latency.
        Thread.Sleep(500);
        // Continue with the next handler in the chain.
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance for Aspose.HTML.
            Configuration configuration = new Configuration();

            // Retrieve the network service from the configuration.
            INetworkService networkService = configuration.GetService<INetworkService>();

            // Insert the custom latency handler at the beginning of the handler chain.
            networkService.MessageHandlers.Insert(0, new LatencyMessageHandler());

            // Define the URL of the HTML document to load.
            string url = "https://example.com";

            // Load the HTML document using the configuration with the latency handler.
            HTMLDocument document = new HTMLDocument(url, configuration);

            // Optionally, output the outer HTML to verify loading.
            Console.WriteLine(((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing.
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}