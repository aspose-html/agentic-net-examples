// Verify that CredentialHandler correctly adds the Authorization header for Basic authentication using Base64.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class BasicAuthValidator : Aspose.Html.Net.MessageHandler
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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new BasicAuthValidator());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/basic-auth/user/passwd");
            request.Credentials = new System.Net.NetworkCredential("user", "passwd");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}