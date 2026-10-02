// Add a correlation ID header to each request using a custom message handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CorrelationIdHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Headers["X-Correlation-ID"] = System.Guid.NewGuid().ToString();
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add the custom message handler
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CorrelationIdHandler());

            // Load an HTML document (example URL)
            using (var document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Output the document title to verify loading
                Console.WriteLine("Document Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}