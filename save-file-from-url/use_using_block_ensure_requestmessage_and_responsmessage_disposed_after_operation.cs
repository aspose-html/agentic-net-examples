// Use a using block to ensure RequestMessage and ResponseMessage are disposed after the operation.

using System;
using System.Collections.Generic;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom handler
            LoggingHandler handler = new LoggingHandler();
            networkService.MessageHandlers.Add(handler);

            // Sample HTML content
            string html = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";

            // Load document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, configuration))
            {
                // Document processing can be done here
            }

            // Output logged messages
            foreach (string message in handler.Messages)
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

// Custom message handler that logs request URI and response status, ensuring disposal
public sealed class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Ensure RequestMessage and ResponseMessage are disposed after the operation
        using (context.Request)
        using (context.Response)
        {
            Next(context);
            _messages.Add($"Request {context.Request.RequestUri} returned status {context.Response.StatusCode}");
        }
    }
}