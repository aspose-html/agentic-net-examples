// Demonstrate loading a protected HTML page using Digest authentication and validate the response content.

using System;
using System.Net;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

public sealed class DigestAuthHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        this.Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
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
                nonce = trimmed.Substring(start).Trim('\"');
                break;
            }
        }
        System.Console.WriteLine("Server nonce: " + nonce);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new DigestAuthHandler());

            string url = "http://example.com/protected";
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage(url);
            request.Credentials = new System.Net.NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                string content = document.DocumentElement != null ? document.DocumentElement.TextContent : string.Empty;
                System.Console.WriteLine("Page content:");
                System.Console.WriteLine(content);

                if (content.Contains("Welcome"))
                {
                    System.Console.WriteLine("Validation succeeded: content contains 'Welcome'.");
                }
                else
                {
                    System.Console.WriteLine("Validation failed: expected keyword not found.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}