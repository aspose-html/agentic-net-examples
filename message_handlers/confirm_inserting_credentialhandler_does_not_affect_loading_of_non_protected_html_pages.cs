// Confirm that inserting CredentialHandler does not affect loading of non-protected HTML pages.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class CredentialHandler : MessageHandler
{
    private readonly System.Net.ICredentials _credentials;
    public CredentialHandler(System.Net.ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new System.Net.NetworkCredential("user", "pass")));

            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}