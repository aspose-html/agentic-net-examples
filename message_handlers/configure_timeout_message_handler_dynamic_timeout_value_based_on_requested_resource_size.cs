// Configure a TimeoutMessageHandler with a dynamic timeout value based on the size of the requested resource.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class DynamicTimeoutMessageHandler : MessageHandler
{
    // Sets a timeout based on a simple heuristic (e.g., URL contains "large")
    public override void Invoke(INetworkOperationContext context)
    {
        int timeoutSeconds = context.Request.RequestUri.ToString().Contains("large") ? 10 : 5;
        context.Request.Timeout = TimeSpan.FromSeconds(timeoutSeconds);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Retrieve the network service and add the custom timeout handler
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new DynamicTimeoutMessageHandler());

            // Load an HTML document using the configuration with the handler applied
            string url = "https://example.com/large-image.html";
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}