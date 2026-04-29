// Verify that the HTMLDocument loads the protected page successfully after CredentialHandler processes authentication.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly System.Net.ICredentials _credentials;
    public CredentialHandler(System.Net.ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        // Attach credentials to the outgoing request
        context.Request.Credentials = _credentials;
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
            Configuration config = new Configuration();

            // Retrieve the network service from the configuration
            INetworkService network = config.GetService<INetworkService>();

            // Add the credential handler with user credentials
            network.MessageHandlers.Add(new CredentialHandler(
                new System.Net.NetworkCredential("username", "password")));

            // Load the protected page using the configuration with credentials
            using (HTMLDocument document = new HTMLDocument("https://example.com/protected", config))
            {
                // Verify that the document was loaded
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}