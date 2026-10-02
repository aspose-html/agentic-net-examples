// Verify that the HTMLDocument loads the protected page successfully after CredentialHandler processes authentication.

public class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.ICredentials credentialsField;
    public CredentialHandler(System.Net.ICredentials credentials)
    {
        this.credentialsField = credentials;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = this.credentialsField;
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new CredentialHandler(new System.Net.NetworkCredential("user", "passwd")));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://httpbin.org/basic-auth/user/passwd", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                System.Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}