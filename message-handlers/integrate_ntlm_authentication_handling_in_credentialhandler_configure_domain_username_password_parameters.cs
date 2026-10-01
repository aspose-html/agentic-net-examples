// Integrate NTLM authentication handling within CredentialHandler by configuring domain, username, and password parameters.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class NtlmCredentialHandler : Aspose.Html.Net.MessageHandler
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
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add NTLM handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new NtlmCredentialHandler());

            // Prepare request with NTLM credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/secure");
            request.Credentials = new NetworkCredential("username", "password", "DOMAIN");
            request.PreAuthenticate = true;

            // Load document using request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                // Save the loaded document to a file
                document.Save("output.html");
                Console.WriteLine("Document saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}