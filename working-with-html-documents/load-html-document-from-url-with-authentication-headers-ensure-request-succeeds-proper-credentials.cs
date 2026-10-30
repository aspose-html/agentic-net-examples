// Load an HTML document from a URL with authentication headers, and ensure the request succeeds with proper credentials.

public class Program
{
    public static void Main()
    {
        try
        {
            string url = "https://example.com";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html))
                {
                    System.Console.WriteLine("Document loaded successfully. Length: " + html.Length);
                }
                else
                {
                    System.Console.WriteLine("Document is empty.");
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

public class BasicAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public BasicAuthHandler()
    {
        _credential = new System.Net.NetworkCredential("username", "password", "domain");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}