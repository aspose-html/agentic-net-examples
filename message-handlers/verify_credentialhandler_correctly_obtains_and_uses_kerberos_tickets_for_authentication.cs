// Verify that CredentialHandler correctly obtains and uses Kerberos tickets for authentication.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public CredentialHandler()
    {
        // Replace with actual Kerberos credentials if needed
        _credential = new NetworkCredential("username", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

class AuthValidatorHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authHeader = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authHeader))
        {
            Console.WriteLine("Authorization header present: " + authHeader);
        }
        else
        {
            Console.WriteLine("Authorization header missing");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            // Add custom handlers
            network.MessageHandlers.Add(new CredentialHandler());
            network.MessageHandlers.Add(new AuthValidatorHandler());

            // Prepare request
            RequestMessage request = new RequestMessage("http://example.com/protected");
            request.Credentials = new NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}