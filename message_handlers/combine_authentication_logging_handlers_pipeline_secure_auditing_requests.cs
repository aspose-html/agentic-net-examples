// Combine authentication and logging handlers in pipeline for secure auditing of requests.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
        {
            context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class LogHandler : MessageHandler
{
    private readonly List<string> _logs = new List<string>();
    public override void Invoke(INetworkOperationContext context)
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
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            LogHandler logger = new LogHandler();
            network.MessageHandlers.Add(logger);
            network.MessageHandlers.Add(new AuthHandler());

            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Document processing can be performed here
            }

            foreach (string entry in logger.Logs)
                Console.WriteLine(entry);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}