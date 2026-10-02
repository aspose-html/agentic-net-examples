// Combine authentication and logging handlers in pipeline for secure auditing of requests.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class authHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class logHandler : Aspose.Html.Net.MessageHandler
{
    private readonly List<string> logsField = new List<string>();
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        logsField.Add("URL: " + context.Request.RequestUri + " | Status: " + context.Response.StatusCode);
    }
    public IReadOnlyList<string> Logs => logsField;
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Add logging and authentication handlers
            logHandler logger = new logHandler();
            network.MessageHandlers.Add(logger);
            network.MessageHandlers.Add(new authHandler());

            // Sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, World!</h1></body></html>";

            // Load document using the configuration (base URI is required for inline content)
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank", configuration))
            {
                // Document is loaded; any network operations would trigger handlers
            }

            // Output logged entries
            foreach (string entry in logger.Logs)
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