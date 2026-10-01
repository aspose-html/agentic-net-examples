// Demonstrate loading a protected HTML page using Digest authentication and validate the response content.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class DigestAuthHandler : Aspose.Html.Net.MessageHandler
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

public class Program
{
    public static void Main()
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
                string content = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine("Page content:");
                System.Console.WriteLine(content);

                if (content.Contains("Welcome"))
                {
                    System.Console.WriteLine("Validation succeeded.");
                }
                else
                {
                    System.Console.WriteLine("Validation failed.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}