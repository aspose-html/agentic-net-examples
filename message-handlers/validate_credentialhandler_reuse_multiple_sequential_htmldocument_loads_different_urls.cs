// Validate that CredentialHandler can be reused for multiple sequential HTMLDocument loads with different URLs.

using System;

class CredentialHandler : Aspose.Html.Net.MessageHandler
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

class Program
{
    static void Main()
    {
        try
        {
            // Create a reusable credential handler
            CredentialHandler credentialHandler = new CredentialHandler(new System.Net.NetworkCredential("user", "pass"));

            // First document load
            Aspose.Html.Configuration configuration1 = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network1 = configuration1.GetService<Aspose.Html.Services.INetworkService>();
            network1.MessageHandlers.Add(credentialHandler);

            using (Aspose.Html.HTMLDocument document1 = new Aspose.Html.HTMLDocument("https://example.com", configuration1))
            {
                Console.WriteLine("Document 1 title: " + document1.Title);
            }

            // Second document load with a different URL
            Aspose.Html.Configuration configuration2 = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network2 = configuration2.GetService<Aspose.Html.Services.INetworkService>();
            network2.MessageHandlers.Add(credentialHandler);

            using (Aspose.Html.HTMLDocument document2 = new Aspose.Html.HTMLDocument("https://example.org", configuration2))
            {
                Console.WriteLine("Document 2 title: " + document2.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}