// Use ProtocolMessageFilter to handle only resources with "http" scheme in conversion workflow.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Net.MessageHandlers;
using Aspose.Html.Net.MessageFilters;
using Aspose.Html.Services;

namespace AsposeHtmlProtocolFilterExample
{
    // Custom handler that processes only "http" scheme resources
    class HttpOnlyHandler : MessageHandler
    {
        public HttpOnlyHandler()
        {
            // Add a filter that matches only "http" protocol
            Filters.Add(new ProtocolMessageFilter("http"));
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
                network.MessageHandlers.Add(new HttpOnlyHandler());

                // Prepare a request message for an HTTP URL
                RequestMessage request = new RequestMessage("http://example.com");

                // Load the HTML document using the request and configuration
                using (HTMLDocument document = new HTMLDocument(request, configuration))
                {
                    // Example usage: output the document title
                    Console.WriteLine("Document title: " + document.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}