// Add Digest authentication support in CredentialHandler by generating HA1 hash from user credentials.

using System;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        if (context.Response.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            return;

        string wwwAuth = context.Response.Headers["WWW-Authenticate"];
        if (string.IsNullOrEmpty(wwwAuth))
            return;

        string realm = string.Empty;
        foreach (string part in wwwAuth.Split(','))
        {
            string trimmed = part.Trim();
            if (trimmed.StartsWith("realm=\"", StringComparison.OrdinalIgnoreCase))
            {
                int firstQuote = trimmed.IndexOf('\"');
                int lastQuote = trimmed.LastIndexOf('\"');
                if (firstQuote >= 0 && lastQuote > firstQuote)
                {
                    realm = trimmed.Substring(firstQuote + 1, lastQuote - firstQuote - 1);
                }
                break;
            }
        }

        if (string.IsNullOrEmpty(realm))
            return;

        var cred = context.Request.Credentials as System.Net.NetworkCredential;
        if (cred == null)
            return;

        string ha1Input = $"{cred.UserName}:{realm}:{cred.Password}";
        using (MD5 md5 = MD5.Create())
        {
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(ha1Input));
            string ha1 = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            Console.WriteLine("HA1 hash: " + ha1);
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
            network.MessageHandlers.Add(new CredentialHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/digest-auth/auth/user/passwd");
            request.Credentials = new System.Net.NetworkCredential("user", "passwd");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}