// Create a CredentialHandler class inheriting from MessageHandler to manage HTTP authentication.

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
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential("user", "password");
            network.MessageHandlers.Add(new CredentialHandler(credential));

            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                System.Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}