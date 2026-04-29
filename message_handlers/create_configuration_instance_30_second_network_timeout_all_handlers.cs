// Create a Configuration instance with a 30‑second network timeout for all handlers.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            // Create a configuration instance
            Configuration configuration = new Configuration();

            // Register a handler that sets a 30‑second timeout for every request
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutHandler());

            // Example usage: load a document with the custom configuration
            using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
            {
                Console.WriteLine("Document loaded with 30‑second network timeout.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    // Message handler that applies a 30‑second timeout to each network request
    public sealed class TimeoutHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(30);
            Next(context);
        }
    }
}