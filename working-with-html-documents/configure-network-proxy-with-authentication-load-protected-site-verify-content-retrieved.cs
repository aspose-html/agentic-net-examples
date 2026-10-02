// Configure network proxy with authentication, load a protected site, and verify content is retrieved.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class ProxyAuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public ProxyAuthHandler()
    {
        _credential = new NetworkCredential("username", "password", "domain");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
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
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new ProxyAuthHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Example Domain"))
                {
                    System.Console.WriteLine("Content retrieved successfully.");
                }
                else
                {
                    System.Console.WriteLine("Content not retrieved or missing expected text.");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}