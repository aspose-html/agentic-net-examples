// Build a timing handler that records start and end timestamps and logs total request duration.

using System;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace TimingHandlerExample
{
    public sealed class RequestTimingHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            DateTime startTime = DateTime.UtcNow;
            Next(context);
            DateTime endTime = DateTime.UtcNow;
            TimeSpan elapsed = endTime - startTime;
            Debug.WriteLine("Request: " + context.Request.RequestUri);
            Debug.WriteLine("Start: " + startTime.ToString("O"));
            Debug.WriteLine("End: " + endTime.ToString("O"));
            Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Create configuration and register the timing handler
                Configuration configuration = new Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();
                networkService.MessageHandlers.Add(new RequestTimingHandler());

                // Load an HTML document using the configuration
                string url = "https://example.com";
                HTMLDocument document = new HTMLDocument(url, configuration);

                // Perform any additional processing if needed
                // For this example, we simply output the document title
                Console.WriteLine("Document loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}