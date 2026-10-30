// Configure network proxy with authentication, load a protected site, and verify content is retrieved.

using System;

public class ProxyAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public ProxyAuthHandler()
    {
        _credential = new System.Net.NetworkCredential("proxyUser", "proxyPassword", "proxyDomain");
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
            network.MessageHandlers.Add(new ProxyAuthHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("https://example.com", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Example Domain"))
                {
                    Console.WriteLine("Content retrieved successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to retrieve expected content.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}