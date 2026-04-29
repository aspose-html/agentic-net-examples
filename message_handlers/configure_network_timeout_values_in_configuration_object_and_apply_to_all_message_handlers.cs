// Configure network timeout values in a Configuration object and apply to all message handlers.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace NetworkTimeoutExample
{
    // Custom handler that sets a timeout for every network request
    public sealed class TimeoutHandler : MessageHandler
    {
        private readonly int _seconds;

        public TimeoutHandler(int seconds)
        {
            _seconds = seconds;
        }

        public override void Invoke(INetworkOperationContext context)
        {
            // Set the request timeout
            context.Request.Timeout = TimeSpan.FromSeconds(_seconds);
            // Continue processing the request
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Create a configuration object
                Configuration configuration = new Configuration();

                // Obtain the network service from the configuration
                INetworkService networkService = configuration.GetService<INetworkService>();

                // Register the timeout handler (e.g., 10 seconds) for all requests
                networkService.MessageHandlers.Add(new TimeoutHandler(10));

                // Load an HTML document using the configured timeout settings
                using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
                {
                    // Perform any processing here; for demonstration we just output the title length
                    Console.WriteLine("Document loaded with configured network timeout.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}