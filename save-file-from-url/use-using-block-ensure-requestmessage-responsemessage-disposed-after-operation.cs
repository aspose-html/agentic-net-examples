// Use a using block to ensure RequestMessage and ResponseMessage are disposed after the operation.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Set a timeout for the request
        context.Request.Timeout = TimeSpan.FromSeconds(10);

        // Ensure request and response are disposed after processing
        using (var request = context.Request)
        using (var response = context.Response)
        {
            Next(context);
            _messages.Add($"Request {request.RequestUri} returned status {response.StatusCode}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom message handler
            var handler = new LoggingHandler();
            networkService.MessageHandlers.Add(handler);

            // Load a document using the configuration (network requests will be logged)
            using (var document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document processing can be done here if needed
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