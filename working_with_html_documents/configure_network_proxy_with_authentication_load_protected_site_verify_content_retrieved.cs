// Configure network proxy with authentication, load a protected site, and verify content is retrieved.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public CredentialHandler()
    {
        // Set proxy/authentication credentials (replace with actual values)
        _credential = new System.Net.NetworkCredential("proxyUser", "proxyPassword", "proxyDomain");
    }

    public override void Invoke(INetworkOperationContext context)
    {
        // Apply credentials to the outgoing request
        context.Request.Credentials = _credential;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the credential handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler());

            // URL of the protected site
            string url = "https://protected.example.com";

            // Load the document using the configuration with proxy authentication
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Retrieve the HTML content
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Verify that expected content is present
                if (!string.IsNullOrEmpty(html) && html.Contains("ExpectedContentMarker"))
                {
                    Console.WriteLine("Content verified successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to verify content.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}