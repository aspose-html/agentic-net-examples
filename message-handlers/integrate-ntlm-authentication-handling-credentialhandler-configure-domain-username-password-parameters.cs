// Integrate NTLM authentication handling within CredentialHandler by configuring domain, username, and password parameters.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Configure NTLM credentials
        string domain = "MYDOMAIN";
        string username = "myuser";
        string password = "mypassword";

        context.Request.Credentials = new NetworkCredential(username, password, domain);
        // Continue processing the request
        Next(context);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create configuration and add the custom credential handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler());

            // Prepare request with pre-authentication enabled
            string url = "https://example.com";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.PreAuthenticate = true;

            // Load the document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
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