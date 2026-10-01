// Verify that CredentialHandler correctly adds the Authorization header for Basic authentication using Base64.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialValidatorHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authValue = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authValue))
            Console.WriteLine("Authorization header present: " + authValue);
        else
            Console.WriteLine("Authorization header missing");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialValidatorHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");
            request.Credentials = new NetworkCredential("testuser", "testpass");
            request.PreAuthenticate = true;

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