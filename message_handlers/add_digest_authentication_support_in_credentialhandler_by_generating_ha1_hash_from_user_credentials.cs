// Add Digest authentication support in CredentialHandler by generating HA1 hash from user credentials.

using System;
using System.Text;
using System.Security.Cryptography;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class DigestHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Proceed with the request/response pipeline first
        Next(context);

        // If the server responded with 401 Unauthorized, attempt to generate HA1 hash
        if (context.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            // Extract realm from WWW-Authenticate header if present
            string wwwAuth = context.Response.Headers["WWW-Authenticate"];
            string realm = string.Empty;
            if (!string.IsNullOrEmpty(wwwAuth))
            {
                foreach (string part in wwwAuth.Split(','))
                {
                    string trimmed = part.Trim();
                    if (trimmed.StartsWith("realm=\"", StringComparison.OrdinalIgnoreCase))
                    {
                        int start = trimmed.IndexOf('\"') + 1;
                        int end = trimmed.LastIndexOf('\"');
                        if (end > start)
                            realm = trimmed.Substring(start, end - start);
                        break;
                    }
                }
            }

            // Retrieve username and password from request credentials
            if (context.Request.Credentials is System.Net.NetworkCredential cred)
            {
                string username = cred.UserName;
                string password = cred.Password;

                // Compute HA1 = MD5(username:realm:password)
                string ha1Input = $"{username}:{realm}:{password}";
                byte[] ha1Bytes = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(ha1Input));
                string ha1Hex = BitConverter.ToString(ha1Bytes).Replace("-", "").ToLowerInvariant();

                Console.WriteLine($"HA1 hash for user '{username}': {ha1Hex}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            Configuration configuration = new Configuration();

            // Get network service and register the digest handler
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new DigestHandler());

            // Prepare request with credentials
            RequestMessage request = new RequestMessage("https://example.com/protected");
            request.Credentials = new System.Net.NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            // Load the HTML document using the request and configuration
            using (HTMLDocument document = new HTMLDocument(request, configuration))
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