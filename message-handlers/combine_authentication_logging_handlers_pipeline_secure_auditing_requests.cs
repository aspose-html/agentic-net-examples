// Combine authentication and logging handlers in pipeline for secure auditing of requests.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : Aspose.Html.Net.MessageHandler
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

class LogHandler : Aspose.Html.Net.MessageHandler
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
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            LogHandler logger = new LogHandler();
            network.MessageHandlers.Add(logger);
            network.MessageHandlers.Add(new AuthHandler());

            string htmlContent = "<html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                // Document processing can be done here if needed
            }

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