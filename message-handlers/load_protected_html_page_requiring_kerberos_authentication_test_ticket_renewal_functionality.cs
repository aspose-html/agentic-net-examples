// Load a protected HTML page requiring Kerberos authentication and test ticket renewal functionality.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public class KerberosHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential credential;

    public KerberosHandler()
    {
        credential = new NetworkCredential("username", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = credential;
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
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new KerberosHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("http://example.com/protected", configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Welcome"))
                {
                    Console.WriteLine("Page loaded successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to load protected content.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}