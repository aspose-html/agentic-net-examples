// Create an HTMLDocument instance with a target URL and the custom Configuration containing CredentialHandler.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    public CredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
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
            // Create custom configuration with credential handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            CredentialHandler credentialHandler = new CredentialHandler(new NetworkCredential("username", "password"));
            network.MessageHandlers.Add(credentialHandler);

            // Load HTML document from URL using the custom configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                // Optionally save the loaded document to a local file
                document.Save("output.html");
                Console.WriteLine("Document loaded and saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}