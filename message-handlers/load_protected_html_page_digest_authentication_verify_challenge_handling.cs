// Load a protected HTML page requiring Digest authentication and verify automatic challenge handling.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestAuthHandler : Aspose.Html.Net.MessageHandler
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
            if (trimmed.StartsWith("nonce=\"", StringComparison.OrdinalIgnoreCase))
            {
                nonce = trimmed.Substring(7, trimmed.Length - 8);
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
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new DigestAuthHandler());

            RequestMessage request = new RequestMessage("http://example.com/protected.html");
            request.Credentials = new NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            using (HTMLDocument document = new HTMLDocument(request, configuration))
            {
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