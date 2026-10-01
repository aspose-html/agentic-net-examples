// Add Digest authentication support in CredentialHandler by generating HA1 hash from user credentials.

using System;
using System.Text;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _username;
    private readonly string _password;
    private readonly string _realm;

    public DigestAuthHandler(string username, string password, string realm)
    {
        _username = username;
        _password = password;
        _realm = realm;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Compute HA1 = MD5(username:realm:password)
        string ha1Input = $"{_username}:{_realm}:{_password}";
        byte[] ha1Bytes = System.Text.Encoding.UTF8.GetBytes(ha1Input);
        byte[] hash;
        using (MD5 md5 = MD5.Create())
        {
            hash = md5.ComputeHash(ha1Bytes);
        }
        StringBuilder sb = new StringBuilder();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("x2"));
        }
        string ha1Hex = sb.ToString();

        // Log the HA1 value (in real scenario you would use it to build the Authorization header)
        System.Console.WriteLine("HA1 (MD5 of username:realm:password): " + ha1Hex);

        // Continue the pipeline
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Configuration and network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add the digest authentication handler
            string username = "user";
            string password = "pass";
            string realm = "exampleRealm";
            network.MessageHandlers.Add(new DigestAuthHandler(username, password, realm));

            // Create request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://httpbin.org/digest-auth/auth/user/pass");
            request.Credentials = new System.Net.NetworkCredential(username, password);
            request.PreAuthenticate = true;

            // Load the document using the request and configuration
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