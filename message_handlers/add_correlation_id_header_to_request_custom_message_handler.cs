// Add a correlation ID header to each request using a custom message handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Retrieve the network service from the configuration
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the custom correlation ID handler
            network.MessageHandlers.Add(new CorrelationIdHandler());

            // Load an HTML document using the configuration (the handler will add the header to each request)
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Access the document title as an example operation
                string title = document.Title;
                Console.WriteLine("Document title: " + title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that adds a correlation ID header to every outgoing request
class CorrelationIdHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Add a unique correlation ID header
        context.Request.Headers["X-Correlation-ID"] = Guid.NewGuid().ToString();

        // Continue processing the request pipeline
        Next(context);
    }
}