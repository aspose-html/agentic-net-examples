// Return 403 Forbidden from authentication handler when API key validation fails.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class ApiKeyAuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["X-Api-Key"]))
        {
            context.Response.StatusCode = System.Net.HttpStatusCode.Forbidden;
            return;
        }
        Next(context);
    }
}

class LogHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> _logs = new List<string>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        _logs.Add("URL: " + context.Request.RequestUri + " | Status: " + context.Response.StatusCode);
    }

    public IReadOnlyList<string> Logs => _logs;
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add authentication and logging handlers
            var authHandler = new ApiKeyAuthHandler();
            var logHandler = new LogHandler();
            network.MessageHandlers.Add(authHandler);
            network.MessageHandlers.Add(logHandler);

            // Load a remote HTML document (no API key provided, will trigger 403)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Document loaded (or failed). Output logs.
                Console.WriteLine("Network operation logs:");
                foreach (var entry in logHandler.Logs)
                {
                    Console.WriteLine(entry);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}