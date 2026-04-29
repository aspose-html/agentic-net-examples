// Implement error handling that retries the download up to three times for transient network errors.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class RetryHandler : MessageHandler
{
    private readonly int _maxRetries;
    public RetryHandler(int maxRetries) { _maxRetries = maxRetries; }
    public override void Invoke(INetworkOperationContext context)
    {
        for (int attempt = 0; attempt <= _maxRetries; attempt++)
        {
            Next(context);
            if ((int)context.Response.StatusCode < 500) break;
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(3));
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