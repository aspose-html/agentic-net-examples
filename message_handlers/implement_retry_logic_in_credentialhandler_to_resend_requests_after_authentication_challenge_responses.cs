// Implement retry logic in CredentialHandler to resend requests after receiving authentication challenge responses.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly ICredentials _credentials;
    private const int MaxRetries = 2;
    private int _retryCount = 0;

    public CredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }

    public override void Invoke(INetworkOperationContext context)
    {
        // Attach credentials to the request before it is sent
        context.Request.Credentials = _credentials;

        // Proceed with the request
        Next(context);

        // If the response indicates an authentication challenge, retry once
        if (context.Response != null && context.Response.StatusCode == HttpStatusCode.Unauthorized && _retryCount < MaxRetries)
        {
            _retryCount++;
            // Re-attach credentials (in case they were cleared) and retry
            context.Request.Credentials = _credentials;
            Next(context);
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the credential handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("username", "password")));

            // Load the protected document using the configured pipeline
            using (HTMLDocument document = new HTMLDocument("https://example.com/protected", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}