// Implement retry logic in CredentialHandler to resend requests after receiving authentication challenge responses.

using System;
using System.Net;

class RetryCredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    private bool _retried;

    public RetryCredentialHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Apply credentials to the request
        context.Request.Credentials = _credentials;

        // Proceed with the request
        Next(context);

        // If unauthorized and we haven't retried yet, retry the request
        if (context.Response != null && context.Response.StatusCode == HttpStatusCode.Unauthorized && !_retried)
        {
            _retried = true;
            Console.WriteLine("Retrying request after authentication challenge.");
            // Ensure credentials are set again
            context.Request.Credentials = _credentials;
            // Retry the request
            Next(context);
        }
    }
}

class AuthHeaderValidatorHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        string authHeader = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authHeader))
            Console.WriteLine("Authorization header present: " + authHeader);
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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryCredentialHandler(new NetworkCredential("user", "passwd")));
            network.MessageHandlers.Add(new AuthHeaderValidatorHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/basic-auth/user/passwd");
            request.PreAuthenticate = true;
            request.Credentials = new NetworkCredential("user", "passwd");

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Document loaded. Length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}