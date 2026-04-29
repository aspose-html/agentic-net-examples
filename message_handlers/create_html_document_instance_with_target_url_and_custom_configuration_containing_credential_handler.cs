// Create an HTMLDocument instance with a target URL and the custom Configuration containing CredentialHandler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class MyCredentialHandler : MessageHandler
{
    private readonly System.Net.ICredentials _credentials;

    public MyCredentialHandler(System.Net.ICredentials credentials)
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
            // Create credentials (replace with actual username and password)
            var credentials = new System.Net.NetworkCredential("username", "password");

            // Instantiate the custom credential handler
            var credentialHandler = new MyCredentialHandler(credentials);

            // Create a custom configuration
            var configuration = new Configuration();

            // Get the network service from the configuration and add the handler
            var networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(credentialHandler);

            // Load the HTML document from the target URL using the custom configuration
            using (var document = new HTMLDocument("https://example.com", configuration))
            {
                // Document is now loaded with the credential handler in place
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}