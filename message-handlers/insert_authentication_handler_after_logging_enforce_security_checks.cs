// Insert an authentication handler after logging to enforce security checks.

using System;
using System.Collections.Generic;
using System.Net;
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
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            string outputPath = "output.html";

            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            var logger = new logHandler();
            network.MessageHandlers.Add(logger);
            network.MessageHandlers.Add(new authHandler());

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
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