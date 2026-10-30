// Implement Basic authentication in CredentialHandler using NetworkCredential with username and password.

using System;

public class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public BasicAuthHandler()
    {
        _credential = new System.Net.NetworkCredential("username", "password", "");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler());

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration);
            string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
            System.Console.WriteLine("Loaded HTML length: " + html.Length);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}