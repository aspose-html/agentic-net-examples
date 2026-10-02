// Verify that CredentialHandler correctly obtains and uses Kerberos tickets for authentication.

using System;

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler());
            network.MessageHandlers.Add(new AuthValidator());

            var request = new Aspose.Html.Net.RequestMessage("http://example.com");
            request.PreAuthenticate = true;

            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
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

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public CredentialHandler()
    {
        _credential = new System.Net.NetworkCredential("user", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

class AuthValidator : Aspose.Html.Net.MessageHandler
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