// Load a protected HTML page requiring NTLM authentication and ensure credentials are correctly applied.

using System;

namespace AsposeHtmlNtlmExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create configuration and obtain network service
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

                // Add a message handler that injects NTLM credentials
                network.MessageHandlers.Add(new CredentialHandler(new System.Net.NetworkCredential("username", "password", "DOMAIN")));

                // Prepare request with pre-authentication
                Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("http://example.com/protected.html");
                request.PreAuthenticate = true;
                request.Credentials = new System.Net.NetworkCredential("username", "password", "DOMAIN");

                // Load the protected HTML document
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
                {
                    string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                    System.Console.WriteLine("Loaded HTML length: " + html.Length);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Message handler that sets credentials for each request
    public class CredentialHandler : Aspose.Html.Net.MessageHandler
    {
        private readonly System.Net.ICredentials _credentials;

        public CredentialHandler(System.Net.ICredentials credentials)
        {
            _credentials = credentials;
        }

        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Credentials = _credentials;
            Next(context);
        }
    }
}