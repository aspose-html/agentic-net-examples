// Confirm that CredentialHandler automatically retries the request after receiving an authentication challenge.

using System;
using System.Net;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add handlers: challenge, credential, validator
            network.MessageHandlers.Add(new ChallengeHandler());
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("user", "pass")));
            network.MessageHandlers.Add(new AuthValidator());

            // Create request
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/secure.html");
            request.PreAuthenticate = true;

            // Load document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded. Title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    // Handler that simulates a server requiring authentication
    class ChallengeHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authHeader))
            {
                context.Response.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                return;
            }
            Next(context);
        }
    }

    // Credential handler that sets credentials (Aspose.Html will retry automatically)
    class CredentialHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly ICredentials credentialsField;
        public CredentialHandler(ICredentials credentials)
        {
            credentialsField = credentials;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Credentials = credentialsField;
            Next(context);
        }
    }

    // Validator that checks if Authorization header is present after retry
    class AuthValidator : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
            string authHeader = context.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authHeader))
                Console.WriteLine("Authorization header present after retry: " + authHeader);
            else
                Console.WriteLine("Authorization header missing after retry");
        }
    }
}