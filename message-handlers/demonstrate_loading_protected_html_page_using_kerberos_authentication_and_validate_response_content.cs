// Demonstrate loading a protected HTML page using Kerberos authentication and validate the response content.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create Aspose.HTML configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get network service and add Kerberos authentication handler
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new KerberosHandler());

            // Load the protected HTML page
            string url = "http://example.com/protected";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Retrieve HTML content
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Validate response content
                if (!string.IsNullOrEmpty(html) && html.Contains("Protected Content"))
                {
                    Console.WriteLine("Page loaded successfully and content validated.");
                }
                else
                {
                    Console.WriteLine("Content validation failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that sets Kerberos credentials
class KerberosHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential credential;

    public KerberosHandler()
    {
        // Replace with actual username, password, and domain
        credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = credential;
        Next(context);
    }
}