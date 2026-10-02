// Configure network service to use a proxy, load a remote page, and ensure resources load through proxy.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class ProxyHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _proxyBase;

    public ProxyHandler(string proxyBase)
    {
        _proxyBase = proxyBase;
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http", "https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string originalUrl = context.Request.RequestUri.ToString();
        string proxiedUrl = _proxyBase + originalUrl;
        context.Request.RequestUri = new Aspose.Html.Url(proxiedUrl);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Proxy address (example)
            string proxyAddress = "http://myproxy:8080/";

            // Configure Aspose.HTML with a custom network handler that routes requests through the proxy
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ProxyHandler(proxyAddress));

            // Remote page to load
            string url = "https://example.com";

            // Create request with timeout
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Timeout = System.TimeSpan.FromSeconds(30);

            // Load document using the configured network service
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = ((Aspose.Html.HTMLElement)document.DocumentElement).OuterHTML;
                Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}