// Configure HttpClient with proxy settings to support extraction behind corporate firewalls.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Configure proxy settings
            var proxy = new WebProxy("http://proxy.example.com:8080", false);
            WebRequest.DefaultWebProxy = proxy;

            // Create Aspose.HTML configuration
            var configuration = new Aspose.Html.Configuration();

            // Optionally, add a message handler for credentials if needed
            // var network = configuration.GetService<INetworkService>();
            // network.MessageHandlers.Add(new ProxyCredentialsHandler(new NetworkCredential("user", "password")));

            // Create request message with target URL
            var request = new Aspose.Html.Net.RequestMessage("https://example.com");

            // Load the document using the configured proxy
            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Save the extracted HTML to a local file
                document.Save("output.html");
            }

            Console.WriteLine("HTML document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Example of a custom message handler to set credentials (optional)
class ProxyCredentialsHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    public ProxyCredentialsHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}