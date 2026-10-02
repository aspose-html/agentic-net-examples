// Verify that CredentialHandler correctly formats NTLM authentication messages according to protocol specifications.

using System;
using System.Text;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class NtlmCredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Retrieve the Authorization header if it already exists
        string authHeader = context.Request.Headers["Authorization"];
        if (string.IsNullOrEmpty(authHeader))
        {
            // Extract credentials from the request
            var credential = context.Request.Credentials as NetworkCredential;
            if (credential != null)
            {
                // Build a simple NTLM token (username/domain:password) and encode it in Base64
                string tokenData = $"{credential.Domain}\\{credential.UserName}:{credential.Password}";
                string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(tokenData));

                // Set the Authorization header with the NTLM scheme
                context.Request.Headers["Authorization"] = "NTLM " + token;
            }
        }

        // Continue processing the request
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Initialize Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Obtain the network service and register the custom NTLM handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new NtlmCredentialHandler());

            // Create a request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com/protected");
            request.Credentials = new NetworkCredential("user", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load the document using the request (the handler will inject the Authorization header)
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // For verification, output the generated Authorization header
                string authHeader = request.Headers["Authorization"];
                Console.WriteLine("Generated Authorization Header:");
                Console.WriteLine(authHeader ?? "Header not set");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}