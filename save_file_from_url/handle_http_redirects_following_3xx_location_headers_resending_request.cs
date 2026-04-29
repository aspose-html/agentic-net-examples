// Handle HTTP redirects by following 3xx Location headers and resending the request.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class RedirectHandler : MessageHandler
{
    private const int MaxRedirects = 5;
    private int _redirectCount = 0;

    public override void Invoke(INetworkOperationContext context)
    {
        // Send the original request
        Next(context);

        // Check if the response is a redirect
        int status = (int)context.Response.StatusCode;
        if (status >= 300 && status < 400 && _redirectCount < MaxRedirects)
        {
            string location = context.Response.Headers["Location"];
            if (!string.IsNullOrEmpty(location))
            {
                _redirectCount++;
                // Update request URI to the new location
                context.Request.RequestUri = new Url(location);
                // Resend the request to the new location
                Next(context);
            }
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the redirect handler
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new RedirectHandler());

            // Load an HTML document (redirects will be followed automatically)
            using (HTMLDocument document = new HTMLDocument("http://example.com/redirect", configuration))
            {
                // Output the document title as a simple verification
                Console.WriteLine(document.Title);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}