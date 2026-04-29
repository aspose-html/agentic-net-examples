// Demonstrate loading a protected HTML page using Basic authentication and validate the response content.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class BasicAuthHandler : MessageHandler
{
    private readonly System.Net.NetworkCredential _credential;

    public BasicAuthHandler()
    {
        // Replace with actual username and password
        _credential = new System.Net.NetworkCredential("username", "password");
    }

    public override void Invoke(INetworkOperationContext context)
    {
        // Apply Basic authentication credentials to the outgoing request
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
            // Prepare Aspose.HTML configuration and register the credential handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new BasicAuthHandler());

            // URL of the protected HTML page
            string url = "https://example.com/protected";

            // Load the page using the configuration that contains the authentication handler
            using (HTMLDocument document = new HTMLDocument(url, configuration))
            {
                // Retrieve the loaded HTML content
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Simple validation of the response content
                if (!string.IsNullOrEmpty(html) && html.Contains("ExpectedContent"))
                {
                    Console.WriteLine("Page loaded and content validated successfully.");
                }
                else
                {
                    Console.WriteLine("Validation failed: content is missing or does not contain the expected text.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}