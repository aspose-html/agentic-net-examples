// Add a custom message handler to log network errors during HTML loading, then output logs to console.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class NetworkLogHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue processing the request/response chain
        Next(context);

        // Log the request URI and response status
        string message = $"Request {context.Request.RequestUri} returned status {context.Response.StatusCode}";
        _messages.Add(message);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration and obtain the network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom message handler to log network activity
            NetworkLogHandler handler = new NetworkLogHandler();
            networkService.MessageHandlers.Add(handler);

            // Load an HTML document (example URL)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document loaded; you can perform additional operations here if needed
            }

            // Output logged messages to console
            foreach (string msg in handler.Messages)
            {
                Console.WriteLine(msg);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}