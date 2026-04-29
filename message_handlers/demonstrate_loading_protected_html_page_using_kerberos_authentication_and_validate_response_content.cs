// Demonstrate loading a protected HTML page using Kerberos authentication and validate the response content.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class KerberosHandler : MessageHandler
{
    private readonly System.Net.NetworkCredential credential;
    public KerberosHandler()
    {
        // Replace with actual username, password, and domain
        credential = new System.Net.NetworkCredential("username", "password", "DOMAIN");
    }
    public override void Invoke(INetworkOperationContext context)
    {
        // Assign Kerberos credentials to the request
        context.Request.Credentials = credential;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create Aspose.HTML configuration
            Configuration configuration = new Configuration();

            // Obtain network service and register the credential handler
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new KerberosHandler());

            // Load the protected HTML page using the configured credentials
            using (HTMLDocument document = new HTMLDocument("http://protected.example.com", configuration))
            {
                // Retrieve the loaded HTML content
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Validate that the expected content is present
                if (!string.IsNullOrEmpty(html) && html.Contains("Welcome"))
                {
                    Console.WriteLine("Page loaded and content validated.");
                }
                else
                {
                    Console.WriteLine("Content validation failed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}