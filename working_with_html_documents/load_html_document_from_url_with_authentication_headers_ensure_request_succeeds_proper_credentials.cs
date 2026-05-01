// Load an HTML document from a URL with authentication headers, and ensure the request succeeds with proper credentials.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public CredentialHandler()
    {
        // Replace with actual username, password and domain
        _credential = new System.Net.NetworkCredential("username", "password", "domain");
    }

    public override void Invoke(INetworkOperationContext context)
    {
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
            // URL of the protected page
            string url = "https://example.com/protected";

            // Create a configuration and register the credential handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler());

            // Load the HTML document using the configuration that contains the handler
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Retrieve the full markup
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}