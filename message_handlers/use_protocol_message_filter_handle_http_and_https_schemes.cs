// Use ProtocolMessageFilter to handle both "http" and "https" schemes for comprehensive coverage.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

namespace AsposeHtmlProtocolFilterExample
{
    // Custom message handler that filters both http and https schemes
    class HttpAndHttpsHandler : MessageHandler
    {
        public HttpAndHttpsHandler()
        {
            // Register filters for "http" and "https" protocols
            Filters.Add(new ProtocolMessageFilter("http", "https"));
        }

        public override void Invoke(INetworkOperationContext context)
        {
            // Continue processing the request
            Next(context);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a configuration instance
                Configuration configuration = new Configuration();

                // Obtain the network service from the configuration
                INetworkService network = configuration.GetService<INetworkService>();

                // Register the custom handler with the network service
                network.MessageHandlers.Add(new HttpAndHttpsHandler());

                // Prepare a request message for a URL (both http and https are supported)
                RequestMessage request = new RequestMessage("https://example.com");

                // Load the HTML document using the request and the configured environment
                using (HTMLDocument document = new HTMLDocument(request, configuration))
                {
                    // Example: output the document title to the console
                    Console.WriteLine("Document Title: " + document.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}