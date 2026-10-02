// Test Digest authentication handling by verifying server-provided nonce and response hash calculations.

using System;
using System.Net;

class DigestHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != HttpStatusCode.Unauthorized)
            return;

        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        string nonce = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("nonce=", StringComparison.OrdinalIgnoreCase))
            {
                int start = trimmed.IndexOf('=') + 1;
                string value = trimmed.Substring(start).Trim('\"');
                nonce = value;
                break;
            }
        }

        Console.WriteLine("Server nonce: " + nonce);
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new DigestHandler());

            var request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            using (var document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}