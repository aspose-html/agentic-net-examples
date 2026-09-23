// Use a retry‑after header from HTTP response to schedule delayed retries for rate‑limited resources.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class RetryAfterHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int maxRetries;
    public RetryAfterHandler(int maxRetries)
    {
        this.maxRetries = maxRetries;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= maxRetries; attempt++)
        {
            // Perform the request
            Next(context);

            int statusCode = (int)context.Response.StatusCode;

            // If request succeeded or client error other than rate limiting, exit loop
            if (statusCode < 500 && statusCode != 429 && statusCode != 503)
                break;

            // Handle rate limiting responses
            if (statusCode == 429 || statusCode == 503)
            {
                string retryAfterValue = context.Response.Headers["Retry-After"];
                int seconds;
                if (!string.IsNullOrEmpty(retryAfterValue) && int.TryParse(retryAfterValue, out seconds))
                {
                    Thread.Sleep(TimeSpan.FromSeconds(seconds));
                }
                else
                {
                    // Default wait time if header is missing or invalid
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }

                // Continue to next attempt
                continue;
            }

            // For other server errors, do not retry
            break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach the custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryAfterHandler(3));

            // Define the URL of the rate‑limited resource
            string url = "https://example.com/rate-limited-resource.html";

            // Load the document using the configuration with the handler
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string html = document.DocumentElement != null ? document.DocumentElement.OuterHTML : string.Empty;
                Console.WriteLine(html);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}