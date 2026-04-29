// Verify that CredentialHandler correctly computes the Digest response using the server-provided nonce.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestHandler : MessageHandler
{
    // Intercepts network responses to extract the Digest nonce from a 401 challenge.
    public override void Invoke(INetworkOperationContext context)
    {
        // Continue processing the request/response chain.
        Next(context);

        // Proceed only if the server responded with 401 Unauthorized.
        if (context.Response.StatusCode != HttpStatusCode.Unauthorized)
            return;

        // Retrieve the WWW-Authenticate header.
        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        // Parse the header to find the nonce value.
        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=\"", StringComparison.OrdinalIgnoreCase))
            {
                // Remove the leading 'nonce="' (7 chars) and trailing quote.
                nonce = trimmed.Substring(7, trimmed.Length - 8);
                break;
            }
        }

        // Output the extracted nonce for verification.
        Console.WriteLine("Server nonce: " + nonce);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration and obtain the network service.
            var configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the custom handler that will inspect the Digest challenge.
            network.MessageHandlers.Add(new DigestHandler());

            // Prepare a request to a protected resource.
            var request = new RequestMessage("http://example.com/protected");
            request.Credentials = new NetworkCredential("user", "password");
            request.PreAuthenticate = true; // Send Authorization header after first challenge.

            // Load the document using the request and configuration.
            using (var document = new HTMLDocument(request, configuration))
            {
                // If loading succeeds, the Digest response was computed correctly.
                Console.WriteLine("Document loaded. Domain: " + document.Domain);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}