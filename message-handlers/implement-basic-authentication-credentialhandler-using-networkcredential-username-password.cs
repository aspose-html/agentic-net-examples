// Implement Basic authentication in CredentialHandler using NetworkCredential with username and password.

using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add credential handler for Basic authentication
            network.MessageHandlers.Add(new CredentialHandler());

            // Load a protected page
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://httpbin.org/basic-auth/user/passwd", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                if (!string.IsNullOrEmpty(html) && html.Contains("authenticated"))
                {
                    Console.WriteLine("Authentication succeeded.");
                }
                else
                {
                    Console.WriteLine("Authentication failed or content not as expected.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Credential handler implementing Basic authentication
class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public CredentialHandler()
    {
        // Username, password, and optional domain (empty for no domain)
        _credential = new NetworkCredential("user", "passwd", "");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}