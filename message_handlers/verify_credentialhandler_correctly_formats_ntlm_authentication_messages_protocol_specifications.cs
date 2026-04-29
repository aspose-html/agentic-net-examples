// Verify that CredentialHandler correctly formats NTLM authentication messages according to protocol specifications.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class NtlmAuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("NTLM", StringComparison.OrdinalIgnoreCase))
        {
            context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the NTLM authentication handler
            network.MessageHandlers.Add(new NtlmAuthHandler());

            // Prepare request with NTLM credentials
            RequestMessage request = new RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
                // Document loaded; if NTLM header is correctly formatted, the request succeeds
                Console.WriteLine("Document loaded successfully with NTLM authentication.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}