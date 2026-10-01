// Create a Configuration object and retrieve INetworkService to attach custom authentication handlers.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Retrieve network service
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Attach custom authentication handler
            network.MessageHandlers.Add(new AuthHeaderValidator());

            // Create request with credentials
            Aspose.Html.Net.RequestMessage request = new Aspose.Html.Net.RequestMessage("https://example.com");
            request.Credentials = new NetworkCredential("user", "password");
            request.PreAuthenticate = true;

            // Load HTML document using the request and configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(request, configuration))
            {
                Console.WriteLine("Document title: " + document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to inspect Authorization header
class AuthHeaderValidator : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue to next handler
        Next(context);

        string authHeader = context.Request.Headers["Authorization"];
        if (!string.IsNullOrEmpty(authHeader))
            Console.WriteLine("Authorization header present: " + authHeader);
        else
            Console.WriteLine("Authorization header missing");
    }
}