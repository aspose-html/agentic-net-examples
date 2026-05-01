// Add a custom message handler to log network errors during HTML loading, then output logs to console.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class LogMessageHandler : MessageHandler
{
    private readonly List<string> _errors = new List<string>();
    public IReadOnlyList<string> Errors => _errors.AsReadOnly();

    public override void Invoke(INetworkOperationContext context)
    {
        // Log error if response status is not OK
        if (context.Response.StatusCode != HttpStatusCode.OK)
        {
            _errors.Add(string.Format("Error loading {0}: {1}", context.Request.RequestUri, context.Response.StatusCode));
        }
        // Continue processing the request
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the custom handler
            var configuration = new Configuration();
            var networkService = configuration.GetService<INetworkService>();
            var handler = new LogMessageHandler();
            networkService.MessageHandlers.Add(handler);

            // Load an HTML document (replace with your URL)
            using (var document = new HTMLDocument("https://example.com/missing.html", configuration))
            {
                // Document is loaded; you can work with it here if needed
            }

            // Output logged network errors to console
            foreach (var error in handler.Errors)
            {
                Console.WriteLine(error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
    }
}