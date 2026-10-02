// Load an HTML document from a URL with authentication headers, and ensure the request succeeds with proper credentials.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // URL to load
            string url = "https://example.com/protected/page.html";

            // Create configuration and attach authentication handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new AuthHandler());

            // Load the HTML document with the configured authentication
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                if (!string.IsNullOrEmpty(html))
                {
                    Console.WriteLine("Document loaded successfully. Length: " + html.Length);
                }
                else
                {
                    Console.WriteLine("Document loaded but contains no content.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that adds network credentials to each request
class AuthHandler : Aspose.Html.Net.MessageHandler
{
    private readonly System.Net.NetworkCredential credential;

    public AuthHandler()
    {
        // Replace with actual username, password, and domain if needed
        credential = new System.Net.NetworkCredential("user", "password", "");
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Credentials = credential;
        Next(context);
    }
}