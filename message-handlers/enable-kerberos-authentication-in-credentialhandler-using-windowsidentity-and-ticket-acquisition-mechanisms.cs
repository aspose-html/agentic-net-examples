// Enable Kerberos authentication in CredentialHandler using WindowsIdentity and ticket acquisition mechanisms.

using System;

class KerberosCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;
    public KerberosCredentialHandler()
    {
        // Placeholder credentials; replace with appropriate Kerberos credentials if needed.
        _credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new KerberosCredentialHandler());

            var request = new Aspose.Html.Net.RequestMessage("http://example.com");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
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