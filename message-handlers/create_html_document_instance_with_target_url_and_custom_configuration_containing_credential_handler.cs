// Create an HTMLDocument instance with a target URL and the custom Configuration containing CredentialHandler.

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

public class Program
{
    public static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new System.Net.NetworkCredential("user", "password")));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Document loaded
            }

            System.Console.WriteLine("HTMLDocument created successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}