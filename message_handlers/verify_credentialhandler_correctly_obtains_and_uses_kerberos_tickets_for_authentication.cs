// Verify that CredentialHandler correctly obtains and uses Kerberos tickets for authentication.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace KerberosDemo
{
    class KerberosCredentialHandler : MessageHandler
    {
        private readonly System.Net.NetworkCredential _credential;
        public KerberosCredentialHandler()
        {
            _credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
        }
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Credentials = _credential;
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var configuration = new Configuration();
                var network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new KerberosCredentialHandler());

                string url = "http://example.com/protected";
                using var document = new HTMLDocument(url, configuration);
                Console.WriteLine("Document title: " + document.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}