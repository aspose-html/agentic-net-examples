// Load a protected HTML page requiring Digest authentication and verify automatic challenge handling.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace DigestAuthExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
                network.MessageHandlers.Add(new DigestAuthHandler());

                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
                request.Credentials = new System.Net.NetworkCredential("user", "password");
                request.PreAuthenticate = true;

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
    }

    class DigestAuthHandler : Aspose.Html.Net.MessageHandler
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
                if (trimmed.StartsWith("nonce=\"", System.StringComparison.OrdinalIgnoreCase))
                {
                    nonce = trimmed.Substring(7, trimmed.Length - 8);
                    break;
                }
            }
            Console.WriteLine("Server nonce: " + nonce);
        }
    }
}