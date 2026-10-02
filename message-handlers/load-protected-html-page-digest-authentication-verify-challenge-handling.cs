// Load a protected HTML page requiring Digest authentication and verify automatic challenge handling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add handler to set credentials (Digest authentication)
            network.MessageHandlers.Add(new CredentialHandler(new System.Net.NetworkCredential("username", "password")));

            // Add optional handler to log server nonce
            network.MessageHandlers.Add(new NonceLoggingHandler());

            // Create request for the protected page
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected.html");
            request.PreAuthenticate = true;

            // Load the HTML document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
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

// Handler that assigns credentials to each request
class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.ICredentials _credentials;
    public CredentialHandler(System.Net.ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

// Handler that logs the server nonce from a 401 Unauthorized response
class NonceLoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            return;

        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=", System.StringComparison.OrdinalIgnoreCase))
            {
                int start = trimmed.IndexOf('=') + 1;
                nonce = trimmed.Substring(start).Trim('\"');
                break;
            }
        }
        System.Console.WriteLine("Server nonce: " + nonce);
    }
}