// Handle HTTP redirects by following 3xx Location headers and resending the request.

using System;
using System.IO;

class RedirectHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // First, let the request proceed normally.
        Next(context);

        // After receiving the response, check for redirect status.
        int statusCode = (int)context.Response.StatusCode;
        if (statusCode >= 300 && statusCode < 400)
        {
            string location = context.Response.Headers["Location"];
            if (!string.IsNullOrEmpty(location))
            {
                // Resolve the new URL against the original request URL.
                Aspose.Html.Url newUrl = new Aspose.Html.Url(location, context.Request.RequestUri.Href);
                context.Request.RequestUri = newUrl;

                // Resend the request to the new location.
                Next(context);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare configuration and network service.
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RedirectHandler());

            // URL that triggers a redirect (example).
            string sourceUrl = "https://httpbin.org/redirect/1";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.html");

            // Load the document using the configuration with redirect handling.
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourceUrl, configuration))
            {
                // Save the final document after following redirects.
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}