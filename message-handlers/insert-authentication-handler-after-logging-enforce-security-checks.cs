// Insert an authentication handler after logging to enforce security checks.

using System;
using System.Collections.Generic;
using System.Net;

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
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            var logger = new LogHandler();
            network.MessageHandlers.Add(logger);
            network.MessageHandlers.Add(new AuthHandler());

            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
            }

            foreach (var entry in logger.Logs)
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