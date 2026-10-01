// Apply TemplateLoadOptions to enable loading templates from a network share with authentication.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and add a custom message handler for credentials
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            var credentialHandler = new BasicAuthHandler(new System.Net.NetworkCredential("user", "pass"));
            networkService.MessageHandlers.Add(credentialHandler);

            // Load an HTML document using the configuration with the handler attached
            using (var document = new Aspose.Html.HTMLDocument("http://example.com/protected.html", configuration))
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

// Custom message handler that injects credentials into each request
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