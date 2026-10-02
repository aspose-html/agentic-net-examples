// Return 403 Forbidden from authentication handler when API key validation fails.

using System;
using System.Net;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class AuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["X-API-Key"]))
        {
            context.Response.StatusCode = HttpStatusCode.Forbidden;
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
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            var authHandler = new AuthHandler();
            var logHandler = new LogHandler();

            network.MessageHandlers.Add(authHandler);
            network.MessageHandlers.Add(logHandler);

            string url = "https://example.com/protected";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }

            Console.WriteLine("Log entries:");
            foreach (var entry in logHandler.Logs)
            {
                Console.WriteLine(entry);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}