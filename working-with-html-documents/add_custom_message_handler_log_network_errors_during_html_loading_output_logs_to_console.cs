// Add a custom message handler to log network errors during HTML loading, then output logs to console.

using System;
using System.Collections.Generic;
using System.Net;

class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue processing the request/response chain
        Next(context);

        // Log the request URI and response status code
        _messages.Add($"Request {context.Request.RequestUri} returned status {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain the network service
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the custom message handler to capture network activity
            var handler = new LogMessageHandler();
            networkService.MessageHandlers.Add(handler);

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load the HTML document using the configuration with the handler attached
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Document is loaded; no further actions required for this example
            }

            // Output logged messages
            foreach (var message in handler.Messages)
            {
                Console.WriteLine(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}