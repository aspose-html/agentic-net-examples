// Integrate NTLM authentication handling within CredentialHandler by configuring domain, username, and password parameters.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace AsposeHtmlNtlmExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Initialize Aspose.HTML configuration
                Configuration configuration = new Configuration();

                // Obtain network service and register the NTLM credential handler
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new CredentialHandler());

                // Create a request message for the target URL
                RequestMessage request = new RequestMessage("http://example.com/protected");

                // Configure NTLM credentials: domain, username, and password
                request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
                request.PreAuthenticate = true;

                // Load the HTML document using the request and configuration
                using (HTMLDocument document = new HTMLDocument(request, configuration))
                {
                    // Example operation: output the document title
                    Console.WriteLine(document.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Custom message handler that validates the presence of an NTLM Authorization header
    class CredentialHandler : MessageHandler
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
}