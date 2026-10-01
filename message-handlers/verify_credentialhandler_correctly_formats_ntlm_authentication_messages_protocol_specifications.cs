// Verify that CredentialHandler correctly formats NTLM authentication messages according to protocol specifications.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add custom NTLM credential handler
            network.MessageHandlers.Add(new NtlmCredentialHandler());

            // Prepare request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com");
            request.Credentials = new System.Net.NetworkCredential("user", "pass", "DOMAIN");
            request.PreAuthenticate = true;

            // Load document (this will trigger the handler)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to verify NTLM Authorization header format
class NtlmCredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string authHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("NTLM ", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Authorization header is missing or not NTLM formatted.");
            context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
            return;
        }

        Console.WriteLine("Authorization header detected: " + authHeader);
        // Continue processing the request
        Next(context);
    }
}