// Add a handler that strips query strings from URLs before they are passed to the network service.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class QueryStripHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Rebuild the request URL without the query string
        string cleanUrl = context.Request.RequestUri.Protocol + "//" + context.Request.RequestUri.Host + context.Request.RequestUri.Pathname;
        context.Request.RequestUri = new Url(cleanUrl);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Retrieve the network service and attach the handler
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new QueryStripHandler());

            // URL containing a query string (will be stripped by the handler)
            string urlWithQuery = "https://example.com/page.html?param=value";

            // Load the document using the configuration with the custom handler
            using (HTMLDocument document = new HTMLDocument(urlWithQuery, configuration))
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