// Handle HTTP redirects by following 3xx Location headers and resending the request.

using System;
using System.Collections.Generic;

class RedirectHandler : Aspose.Html.Net.MessageHandler
{
    private const int MaxRedirects = 5;
    private readonly Dictionary<string, int> _redirectCounts = new Dictionary<string, int>();

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // First attempt
        Next(context);

        int statusCode = (int)context.Response.StatusCode;
        if (statusCode >= 300 && statusCode < 400)
        {
            object locationHeader = context.Response.Headers["Location"];
            if (locationHeader != null)
            {
                string location = locationHeader.ToString();
                string requestKey = context.Request.RequestUri.ToString();

                int count = 0;
                if (_redirectCounts.TryGetValue(requestKey, out int existing))
                {
                    count = existing;
                }

                if (count < MaxRedirects)
                {
                    _redirectCounts[requestKey] = count + 1;

                    // Resolve new URL (absolute or relative)
                    Aspose.Html.Url newUrl;
                    if (Uri.IsWellFormedUriString(location, UriKind.Absolute))
                    {
                        newUrl = new Aspose.Html.Url(location);
                    }
                    else
                    {
                        // Combine with base URL
                        string baseUrl = context.Request.RequestUri.Protocol + "://" + context.Request.RequestUri.Host + context.Request.RequestUri.Pathname;
                        newUrl = new Aspose.Html.Url(baseUrl, location);
                    }

                    context.Request.RequestUri = newUrl;

                    // Resend the request after redirect
                    Next(context);
                }
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
            // Input URL that may redirect
            string url = "http://httpbin.org/redirect/1";
            // Output file path
            string outputPath = "output.html";

            // Create configuration and add redirect handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RedirectHandler());

            // Load document with configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
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