// Create a configuration that includes both start and stop duration logging handlers for detailed performance metrics.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

namespace DurationLoggingExample
{
    // Base handler that provides shared timer storage and helper methods
    abstract class BaseHandler : MessageHandler
    {
        protected static readonly ConcurrentDictionary<Url, Stopwatch> timers = new ConcurrentDictionary<Url, Stopwatch>();

        protected void StartTimer(Url url)
        {
            timers[url] = Stopwatch.StartNew();
        }

        protected TimeSpan StopTimer(Url url)
        {
            if (timers.TryRemove(url, out Stopwatch sw))
            {
                sw.Stop();
                return sw.Elapsed;
            }
            return TimeSpan.Zero;
        }
    }

    // Handler that starts the timer before the request is processed
    class StartHandler : BaseHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            StartTimer(context.Request.RequestUri);
            Next(context);
        }
    }

    // Handler that stops the timer after the request completes and logs the duration
    class StopHandler : BaseHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            Next(context);
            TimeSpan duration = StopTimer(context.Request.RequestUri);
            Console.WriteLine($"Elapsed: {duration.TotalMilliseconds} ms | {context.Request.RequestUri}");
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                // Create configuration and attach the start/stop handlers
                Configuration configuration = new Configuration();
                INetworkService network = configuration.GetService<INetworkService>();
                network.MessageHandlers.Add(new StartHandler());
                network.MessageHandlers.Add(new StopHandler());

                // Load a document using the configured network service
                using (HTMLDocument document = new HTMLDocument("https://example.com", configuration))
                {
                    // Document processing can be performed here
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}