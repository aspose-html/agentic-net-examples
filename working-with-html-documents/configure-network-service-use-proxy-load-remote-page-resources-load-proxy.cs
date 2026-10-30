// Configure network service to use a proxy, load a remote page, and ensure resources load through proxy.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL to load
            string url = "https://example.com";

            // Create configuration and set up network service with proxy handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ProxyHandler());

            // Create request with timeout
            RequestMessage request = new RequestMessage(url);
            request.Timeout = TimeSpan.FromSeconds(30);

            // Load document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                string html = ((HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that routes all requests through a proxy server
class ProxyHandler : Aspose.Html.Net.MessageHandler
{
    public ProxyHandler()
    {
        // Apply to both HTTP and HTTPS protocols
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http"));
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Original request URI
        Aspose.Html.Url originalUrl = context.Request.RequestUri;
        string original = originalUrl.Protocol + "://" + originalUrl.Host + originalUrl.Pathname + originalUrl.Search + originalUrl.Hash;

        // Proxy server address (example)
        string proxyAddress = "http://proxy.example.com:8080/";

        // Rewrite request to go through the proxy
        context.Request.RequestUri = new Aspose.Html.Url(proxyAddress + original);

        // Continue processing
        Next(context);
    }
}