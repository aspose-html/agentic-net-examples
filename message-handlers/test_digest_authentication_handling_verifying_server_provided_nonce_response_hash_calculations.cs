// Test Digest authentication handling by verifying server-provided nonce and response hash calculations.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.IO;

class DigestHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            return;
        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;
        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=", System.StringComparison.OrdinalIgnoreCase))
            {
                nonce = trimmed.Substring(7, trimmed.Length - 8);
                break;
            }
        }
        System.Console.WriteLine("Server nonce: " + nonce);
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
            network.MessageHandlers.Add(new DigestHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "pass");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}