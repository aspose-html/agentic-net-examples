// Add Digest authentication support in CredentialHandler by generating HA1 hash from user credentials.

using System;
using System.Security.Cryptography;
using System.Text;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestCredentialHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        var cred = context.Request.Credentials as System.Net.NetworkCredential;
        if (cred != null)
        {
            // Placeholder realm and nonce for demonstration
            string realm = "exampleRealm";
            string nonce = "exampleNonce";

            string ha1 = ComputeMD5($"{cred.UserName}:{realm}:{cred.Password}");
            string method = "GET";
            string uri = context.Request.RequestUri != null ? context.Request.RequestUri.ToString() : "/";
            string ha2 = ComputeMD5($"{method}:{uri}");
            string response = ComputeMD5($"{ha1}:{nonce}:{ha2}");

            string authHeader = $"Digest username=\"{cred.UserName}\", realm=\"{realm}\", nonce=\"{nonce}\", uri=\"{uri}\", response=\"{response}\"";
            context.Request.Headers["Authorization"] = authHeader;
        }

        Next(context);
    }

    private static string ComputeMD5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
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
            network.MessageHandlers.Add(new DigestCredentialHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}