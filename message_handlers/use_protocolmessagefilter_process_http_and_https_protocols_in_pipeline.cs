// Use ProtocolMessageFilter to process only HTTP and HTTPS protocols in the pipeline.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageHandlers;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

class HttpHttpsHandler : MessageHandler
{
    public HttpHttpsHandler()
    {
        Filters.Add(new ProtocolMessageFilter("http", "https"));
    }

    public override void Invoke(INetworkOperationContext context)
    {
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
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new HttpHttpsHandler());

            // Create request for the desired URL
            RequestMessage request = new RequestMessage("https://example.com");

            // Load the document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                // Example operation: output the document title
                Console.WriteLine("Document Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}