// Load a protected HTML page requiring Basic authentication by providing NetworkCredential to CredentialHandler.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;

    public BasicAuthHandler(ICredentials credentials)
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
            // Create configuration and add authentication handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler(new NetworkCredential("username", "password", "domain")));

            // Load protected HTML page
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com/protected", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}