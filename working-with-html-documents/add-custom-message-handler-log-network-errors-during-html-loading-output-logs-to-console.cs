// Add a custom message handler to log network errors during HTML loading, then output logs to console.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue the pipeline first
        Next(context);

        // Log the request and response status
        if (context.Response.StatusCode != HttpStatusCode.OK)
        {
            _messages.Add(string.Format("Error loading {0}: {1} ({2})",
                context.Request.RequestUri,
                (int)context.Response.StatusCode,
                context.Response.StatusCode));
        }
        else
        {
            _messages.Add(string.Format("Request {0} returned status {1}",
                context.Request.RequestUri,
                context.Response.StatusCode));
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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom message handler
            LogMessageHandler handler = new LogMessageHandler();
            networkService.MessageHandlers.Add(handler);

            // Load an HTML document (example URL)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document is loaded; nothing else needed for this example
            }

            // Output logged messages
            foreach (string message in handler.Messages)
            {
                System.Console.WriteLine(message);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}