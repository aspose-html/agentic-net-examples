// Handle HTTP redirects by following 3xx Location headers and resending the request.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach redirect handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RedirectHandler());

            // Input URL (may respond with a 3xx redirect) and output file path
            string url = "http://example.com/redirect";
            string outputPath = "output.html";

            // Load the document using the configuration with the redirect handler
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Message handler that follows a single HTTP redirect (3xx) by resending the request to the Location header.
class RedirectHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Perform the initial request
        Next(context);

        // Check for redirect status code
        int statusCode = (int)context.Response.StatusCode;
        if (statusCode >= 300 && statusCode < 400)
        {
            // Get the Location header value
            object locationHeader = context.Response.Headers["Location"];
            if (locationHeader != null)
            {
                string location = locationHeader.ToString();
                if (!string.IsNullOrEmpty(location))
                {
                    // Update request URI to the new location and resend the request
                    context.Request.RequestUri = new Aspose.Html.Url(location);
                    Next(context);
                }
            }
        }
    }
}