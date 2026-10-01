// Configure network proxy with authentication, load a protected site, and verify content is retrieved.

using System;
using System.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.Html configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Get the network service from the configuration
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add a custom message handler that supplies credentials
            network.MessageHandlers.Add(new CredentialHandler());

            // Load an HTML document from a URL using the configured network service
            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                // Retrieve the outer HTML of the document element
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Output some information about the loaded HTML
                Console.WriteLine("Loaded HTML length: " + html.Length);
                if (!string.IsNullOrEmpty(html) && html.Contains("Example Domain"))
                {
                    Console.WriteLine("The page contains the expected text.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler that adds network credentials to each request
class CredentialHandler : Aspose.Html.Net.MessageHandler
{
    private readonly NetworkCredential _credential;

    public CredentialHandler()
    {
        // Replace with appropriate credentials if needed
        _credential = new NetworkCredential("username", "password", "domain");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = _credential;
        Next(context);
    }
}