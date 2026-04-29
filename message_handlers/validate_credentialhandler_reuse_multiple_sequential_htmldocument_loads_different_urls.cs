// Validate that CredentialHandler can be reused for multiple sequential HTMLDocument loads with different URLs.

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
            // Create a single credential handler instance
            var credentialHandler = new CredentialHandler(new System.Net.NetworkCredential("user", "password"));

            // First configuration and document load
            var configuration1 = new Configuration();
            var network1 = configuration1.GetService<INetworkService>();
            network1.MessageHandlers.Add(credentialHandler);
            using (var document1 = new HTMLDocument("https://example.com/page1.html", configuration1))
            {
                Console.WriteLine("Document 1 loaded successfully.");
            }

            // Second configuration and document load using the same handler
            var configuration2 = new Configuration();
            var network2 = configuration2.GetService<INetworkService>();
            network2.MessageHandlers.Add(credentialHandler);
            using (var document2 = new HTMLDocument("https://example.com/page2.html", configuration2))
            {
                Console.WriteLine("Document 2 loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}