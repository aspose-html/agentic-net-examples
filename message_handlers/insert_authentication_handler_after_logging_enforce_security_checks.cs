// Insert an authentication handler after logging to enforce security checks.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Simple authentication check: require a custom header "X-Auth-Token"
        if (string.IsNullOrEmpty(context.Request.Headers["X-Auth-Token"]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
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
            // Create configuration and obtain network service
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register logging handler first
            LogHandler logger = new LogHandler();
            network.MessageHandlers.Add(logger);

            // Register authentication handler after logging
            network.MessageHandlers.Add(new AuthHandler());

            // Load an HTML document using the configured network service
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Save the document to a local file
                string outputPath = "output.html";
                document.Save(outputPath);
            }

            // Output logged entries
            foreach (string entry in logger.Logs)
                Console.WriteLine(entry);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}