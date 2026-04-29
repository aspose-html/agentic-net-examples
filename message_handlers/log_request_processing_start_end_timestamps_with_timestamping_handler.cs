// Log request processing start and end timestamps with a timestamping handler.

using System;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace TimestampLoggingExample
{
    // Handler that logs start and end timestamps of each request
    public sealed class TimestampLoggingHandler : MessageHandler
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
                // Create configuration and register the timestamp logging handler
                Configuration configuration = new Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();
                networkService.MessageHandlers.Add(new TimestampLoggingHandler());

                // Load an HTML document using the configured pipeline
                string documentPath = "sample.html"; // replace with actual path
                using (HTMLDocument document = new HTMLDocument(documentPath, configuration))
                {
                    // Document is loaded; further processing can be done here
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}