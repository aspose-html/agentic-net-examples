// Configure HttpClient with proxy settings to support extraction behind corporate firewalls.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class ProxyCredentialsHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;

    public ProxyCredentialsHandler(ICredentials credentials)
    {
        _credentials = credentials;
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http", "https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configure Aspose.HTML with proxy credentials
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ProxyCredentialsHandler(new NetworkCredential("proxyUser", "proxyPass")));

            // Create request to load a web page through the proxy
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the document using the configured network settings
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Page title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}