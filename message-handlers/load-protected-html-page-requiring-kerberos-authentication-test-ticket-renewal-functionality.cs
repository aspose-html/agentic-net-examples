// Load a protected HTML page requiring Kerberos authentication and test ticket renewal functionality.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach Kerberos handler
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new KerberosHandler());

            // URL of the protected page (replace with actual URL if needed)
            var url = "http://example.com/protected";

            // First load (initial ticket)
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Protected"))
                    Console.WriteLine("First load succeeded.");
                else
                    Console.WriteLine("First load completed, content check failed.");
            }

            // Second load (simulating ticket renewal)
            using (var document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                if (!string.IsNullOrEmpty(html) && html.Contains("Protected"))
                    Console.WriteLine("Second load (ticket renewal) succeeded.");
                else
                    Console.WriteLine("Second load completed, content check failed.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to provide Kerberos credentials
public class KerberosHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public KerberosHandler()
    {
        // Replace with actual username, password, and domain
        _credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}