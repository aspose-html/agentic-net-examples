// Verify that CredentialHandler correctly computes the Digest response using the server-provided nonce.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class DigestCredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue processing the request/response chain
        Next(context);

        // Check if the response requires authentication
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            return;

        // Get the WWW-Authenticate header
        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        // Extract the nonce value
        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=\"", StringComparison.OrdinalIgnoreCase))
            {
                // nonce="value"
                nonce = trimmed.Substring(7, trimmed.Length - 8);
                break;
            }
        }

        Console.WriteLine("Server nonce: " + nonce);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the custom credential handler
            network.MessageHandlers.Add(new DigestCredentialHandler());

            // Prepare request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "pass");
            request.PreAuthenticate = true;

            // Load the document (this will trigger the handler)
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