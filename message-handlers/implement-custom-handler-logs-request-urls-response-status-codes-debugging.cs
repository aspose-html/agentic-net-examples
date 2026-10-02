// Implement a custom handler that logs request URLs and response status codes for debugging.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _messages = new List<string>();
    public IReadOnlyList<string> Messages => _messages.AsReadOnly();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        _messages.Add("Request " + context.Request.RequestUri + " returned status " + context.Response.StatusCode);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add custom handler
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            LogMessageHandler handler = new LogMessageHandler();
            networkService.MessageHandlers.Add(handler);

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";

            // Load document using inline HTML
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Document is loaded; any network requests (e.g., external resources) will be logged by the handler
            }

            // Output logged messages
            foreach (string message in handler.Messages)
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