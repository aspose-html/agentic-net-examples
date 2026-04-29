// Return 403 Forbidden from authentication handler when API key validation fails.

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
            // Create a configuration instance
            var configuration = new Configuration();

            // Obtain the network service from the configuration
            var network = configuration.GetService<INetworkService>();

            // Register the authentication handler
            network.MessageHandlers.Add(new ApiKeyAuthHandler());

            // Load an HTML document using the configured network service
            using (var document = new HTMLDocument("https://example.com", configuration))
            {
                // Save the document to trigger network requests
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Authentication handler that returns 403 Forbidden when the API key header is missing or empty
class ApiKeyAuthHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Check for the presence of the API key header
        if (string.IsNullOrEmpty(context.Request.Headers["X-API-KEY"]))
        {
            // Set response status to 403 Forbidden and stop further processing
            context.Response.StatusCode = System.Net.HttpStatusCode.Forbidden;
            return;
        }

        // Continue with the next handler in the pipeline
        Next(context);
    }
}