// Implement a retry policy with exponential backoff for transient failures when downloading large files.

using System;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class RetryHandler : MessageHandler
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
            if ((int)context.Response.StatusCode < 500) break;
            if (attempt < _maxRetries)
            {
                int delay = (int)Math.Pow(2, attempt) * 1000;
                Thread.Sleep(delay);
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
            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new RetryHandler(5));

            using (HTMLDocument document = new HTMLDocument("https://example.com/largefile.html", configuration))
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