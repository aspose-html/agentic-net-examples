// Create a CredentialHandler class inheriting from MessageHandler to manage HTTP authentication.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly ICredentials _credentials;

    public CredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }

    public override void Invoke(INetworkOperationContext context)
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
            // Create configuration and obtain network service
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Add custom credential handler with network credentials
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("username", "password")));

            // Prepare request message for the target URL
            RequestMessage request = new RequestMessage("https://example.com");

            // Load the HTML document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                // Example operation: output the document title
                Console.WriteLine(document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}