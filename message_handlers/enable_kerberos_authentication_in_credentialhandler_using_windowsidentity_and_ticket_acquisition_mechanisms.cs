// Enable Kerberos authentication in CredentialHandler using WindowsIdentity and ticket acquisition mechanisms.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new KerberosCredentialHandler());

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com/secure");
            request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
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

    class KerberosCredentialHandler : Aspose.Html.Net.MessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            context.Request.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            Next(context);
        }
    }
}