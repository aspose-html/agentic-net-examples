// Implement an authentication handler that validates required headers and returns error response when missing.

using System;
using System.Net;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class AuthHandler : Aspose.Html.Net.MessageHandler
{
    // Checks for the required header and returns 401 if missing
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        if (string.IsNullOrEmpty(context.Request.Headers["X-Auth-Token"]))
        {
            context.Response.StatusCode = HttpStatusCode.Unauthorized;
            return;
        }
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Register the authentication handler
            network.MessageHandlers.Add(new AuthHandler());

            // Load a document using the configured network pipeline
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                // Save the document to verify successful load
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}