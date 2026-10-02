// Load a protected HTML page requiring Kerberos authentication and test ticket renewal functionality.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Dom;

public class KerberosHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public KerberosHandler()
    {
        _credential = new NetworkCredential("username", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Create configuration and add Kerberos handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new KerberosHandler());

            // Load protected HTML page
            string url = "http://example.com/protected";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                if (!string.IsNullOrEmpty(html) && html.Contains("Welcome"))
                {
                    Console.WriteLine("Page loaded successfully and contains expected content.");
                }
                else
                {
                    Console.WriteLine("Page loaded, but expected content was not found.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}