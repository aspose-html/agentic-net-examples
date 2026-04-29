// Load a protected HTML page requiring Basic authentication by providing NetworkCredential to CredentialHandler.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class BasicAuthHandler : MessageHandler
{
    private readonly ICredentials _credentials;
    public BasicAuthHandler(ICredentials credentials)
    {
        _credentials = credentials;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        // Attach credentials to the outgoing request
        context.Request.Credentials = _credentials;
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Obtain the network service from the configuration
            INetworkService network = configuration.GetService<INetworkService>();

            // Define basic authentication credentials (username and password)
            var credentials = new NetworkCredential("username", "password");

            // Register the credential handler with the network service
            network.MessageHandlers.Add(new BasicAuthHandler(credentials));

            // Load the protected HTML page using the prepared configuration
            using (HTMLDocument document = new HTMLDocument("https://example.com/protected", configuration))
            {
                // Retrieve the loaded HTML content
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;

                // Output basic information about the loaded document
                Console.WriteLine("Loaded HTML length: " + html.Length);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during loading
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}