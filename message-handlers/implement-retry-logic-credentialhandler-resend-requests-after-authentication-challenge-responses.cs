// Implement retry logic in CredentialHandler to resend requests after receiving authentication challenge responses.

using System;
using System.Net;
using Aspose.Html.Net;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private const string RetryHeader = "X-Retry-Attempt";

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // First attempt
        Next(context);

        if (context.Response == null)
            return;

        if (context.Response.StatusCode == HttpStatusCode.Unauthorized)
        {
            // Check if we already retried
            if (context.Request.Headers[RetryHeader] == "1")
                return; // already retried, give up

            // Mark retry
            context.Request.Headers[RetryHeader] = "1";

            // Optionally log the nonce (example)
            string wwwAuth = context.Response.Headers["WWW-Authenticate"];
            if (!string.IsNullOrEmpty(wwwAuth))
            {
                string nonce = string.Empty;
                foreach (string part in wwwAuth.Split(','))
                {
                    string trimmed = part.Trim();
                    if (trimmed.StartsWith("nonce=", StringComparison.OrdinalIgnoreCase))
                    {
                        nonce = trimmed.Substring(7, trimmed.Length - 8);
                        break;
                    }
                }
                Console.WriteLine("Server nonce: " + nonce);
            }

            // Retry the request
            Next(context);
        }
    }
}

class AuthHeaderValidator : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authValue = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authValue))
            Console.WriteLine("Authorization header present: " + authValue);
        else
            Console.WriteLine("Authorization header missing");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add handlers: retry logic and header validator
            network.MessageHandlers.Add(new CredentialHandler());
            network.MessageHandlers.Add(new AuthHeaderValidator());

            // Prepare request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/basic-auth/user/passwd");
            request.Credentials = new NetworkCredential("user", "passwd");
            request.PreAuthenticate = true;

            // Load document using the request
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Output some content to verify successful load
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