// Retrieve the INetworkService from the Configuration object to enable network operations.

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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            LoggingHandler handler = new LoggingHandler();
            networkService.MessageHandlers.Add(handler);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document loaded; you can access its properties if needed
                Console.WriteLine("Document title: " + document.Title);
            }

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