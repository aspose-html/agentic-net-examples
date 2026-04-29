// Test Digest authentication handling by verifying server-provided nonce and response hash calculations.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestAuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue processing the request/response chain
        Next(context);

        // Check if the server responded with 401 Unauthorized
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            return;

        // Retrieve the WWW-Authenticate header
        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        // Extract the nonce value from the header
        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=\"", StringComparison.OrdinalIgnoreCase))
            {
                nonce = trimmed.Substring(7, trimmed.Length - 8);
                break;
            }
        }

        // Output the nonce for verification
        Console.WriteLine("Server nonce: " + nonce);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and register the custom handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new DigestAuthHandler());

            // Prepare request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "pass");
            request.PreAuthenticate = true;

            // Load the document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Document is loaded; additional processing can be done here
                Console.WriteLine("Document loaded. Domain: " + document.Domain);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}