// Add a TimeoutMessageHandler after logging handlers to ensure timeout enforcement occurs last.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace AsposeHtmlTimeoutExample
{
    // Logging handler that records request start and end times
    public sealed class LoggingHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            DateTime startTime = DateTime.UtcNow;
            Next(context);
            DateTime endTime = DateTime.UtcNow;
            TimeSpan elapsed = endTime - startTime;
            System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
            System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
            System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
            System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
        }
    }

    // Timeout handler that enforces a request timeout
    public sealed class TimeoutMessageHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            // Set timeout to 30 seconds
            context.Request.Timeout = TimeSpan.FromSeconds(30);
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Create configuration
                Configuration configuration = new Configuration();

                // Get network service from configuration
                INetworkService networkService = configuration.GetService<INetworkService>();

                // Add logging handler first
                networkService.MessageHandlers.Add(new LoggingHandler());

                // Add timeout handler after logging handlers
                networkService.MessageHandlers.Add(new TimeoutMessageHandler());

                // Load HTML document using the configured handlers
                using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
                {
                    // Save the document to a local file
                    document.Save("output.html");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}