// Load a protected HTML page requiring NTLM authentication and ensure credentials are correctly applied.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class NtlmHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
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

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new NtlmHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine(document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}