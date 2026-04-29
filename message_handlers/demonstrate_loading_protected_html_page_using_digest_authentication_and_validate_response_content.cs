// Demonstrate loading a protected HTML page using Digest authentication and validate the response content.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestAuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized) return;
        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth)) return;
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
}

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new DigestAuthHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html))
                {
                    Console.WriteLine("Page loaded successfully. Length: " + html.Length);
                }
                else
                {
                    Console.WriteLine("Failed to load page content.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}