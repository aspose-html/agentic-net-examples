// Implement retry logic in CredentialHandler to resend requests after receiving authentication challenge responses.

using System;
using System.Collections.Generic;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly ICredentials _credentials;
    private readonly int _maxRetries;
    private readonly Dictionary<string, int> _retryCounts = new Dictionary<string, int>();

    public CredentialHandler(ICredentials credentials, int maxRetries = 1)
    {
        _credentials = credentials;
        _maxRetries = maxRetries;
    }

    public override void Invoke(INetworkOperationContext context)
    {
        if (context.Request.Credentials == null)
        {
            context.Request.Credentials = _credentials;
        }

        Next(context);

        if (context.Response != null && context.Response.StatusCode == HttpStatusCode.Unauthorized)
        {
            string key = context.Request.RequestUri.ToString();
            int count = 0;
            if (_retryCounts.TryGetValue(key, out count) && count >= _maxRetries)
            {
                return;
            }

            _retryCounts[key] = count + 1;
            Console.WriteLine($"Retrying request to {key}, attempt {_retryCounts[key]}");

            context.Request.Credentials = _credentials;
            Next(context);
        }
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
            network.MessageHandlers.Add(new CredentialHandler(new NetworkCredential("user", "passwd")));

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/basic-auth/user/passwd");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}