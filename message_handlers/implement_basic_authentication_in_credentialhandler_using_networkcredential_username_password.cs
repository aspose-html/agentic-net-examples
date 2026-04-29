// Implement Basic authentication in CredentialHandler using NetworkCredential with username and password.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.ICredentials _credentials;
    public BasicAuthHandler(System.Net.ICredentials credentials)
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
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler(new System.Net.NetworkCredential("username", "password")));

            using (var document = new Aspose.Html.HTMLDocument("https://example.com/protected", configuration))
            {
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