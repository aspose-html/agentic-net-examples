// Implement a custom handler that logs request URLs and response status codes for debugging.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class RequestLogger : MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request/response chain
        Next(context);
        // Log the request URI and response status code
        _messages.Add("Request " + context.Request.RequestUri + " returned status " + context.Response.StatusCode);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a configuration instance
            var configuration = new Configuration();

            // Obtain the network service from the configuration
            var networkService = configuration.GetService<INetworkService>();

            // Instantiate and register the custom message handler
            var handler = new RequestLogger();
            networkService.MessageHandlers.Add(handler);

            // Load an HTML document using the configuration (example URL)
            using (var document = new HTMLDocument("https://example.com", configuration))
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
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}