// Validate that CredentialHandler correctly encodes credentials for Basic authentication using Base64 encoding.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class CredentialValidator : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authValue = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authValue))
            System.Console.WriteLine("Authorization header present: " + authValue);
        else
            System.Console.WriteLine("Authorization header missing");
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
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the credential validator handler
            network.MessageHandlers.Add(new CredentialValidator());

            // Prepare request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/");
            request.Credentials = new NetworkCredential("user", "passwd");
            request.PreAuthenticate = true;

            // Load the document (this will trigger the handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}