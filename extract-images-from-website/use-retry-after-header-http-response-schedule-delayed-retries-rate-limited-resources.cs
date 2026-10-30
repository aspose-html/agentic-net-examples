// Use a retry‑after header from HTTP response to schedule delayed retries for rate‑limited resources.

using System;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and attach custom retry‑after handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new RetryAfterHandler(3));

            // Load a URL that may return 429 with a Retry-After header
            string url = "https://httpbin.org/response-headers?Retry-After=2&status=429";
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

// Custom message handler that respects the Retry-After header
class RetryAfterHandler : Aspose.Html.Net.MessageHandler
{
    private readonly int _maxRetries;

    public RetryAfterHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            // Perform the request
            Next(context);

            int statusCode = (int)context.Response.StatusCode;

            // If request succeeded or is not a rate‑limit response, exit loop
            if (statusCode < 500 && statusCode != 429)
                break;

            // Handle 429 Too Many Requests with Retry-After header
            if (statusCode == 429)
            {
                string retryAfterValue = null;
                try
                {
                    // Attempt to read the header; indexer returns null if missing
                    retryAfterValue = context.Response.Headers["Retry-After"];
                }
                catch
                {
                    // Ignore any exception while accessing headers
                }

                int delaySeconds = 2; // default fallback
                if (!string.IsNullOrEmpty(retryAfterValue) && int.TryParse(retryAfterValue, out int parsed))
                {
                    delaySeconds = parsed;
                }

                Thread.Sleep(TimeSpan.FromSeconds(delaySeconds));
            }
            else
            {
                // For other server errors, optionally break or continue; here we break
                break;
            }
        }
    }
}