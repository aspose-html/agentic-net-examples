// Add a custom handler that retries failed network requests up to three times before aborting.

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
            Configuration configuration = new Configuration();

            // Retrieve the network service and register the retry handler (max 3 retries)
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));

            // Load an HTML document using the configured retry handler
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                Console.WriteLine("Document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom message handler that retries failed network requests up to a specified number of times
class RetryHandler : MessageHandler
{
    private readonly int _maxRetries;

    public RetryHandler(int maxRetries)
    {
        _maxRetries = maxRetries;
    }

    public override void Invoke(INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            // Stop retrying if the response status code indicates success (non‑5xx)
            if ((int)context.Response.StatusCode < 500)
                break;
        }
    }
}