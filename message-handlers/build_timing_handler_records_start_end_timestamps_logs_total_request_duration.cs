// Build a timing handler that records start and end timestamps and logs total request duration.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace AsposeHtmlTimingExample
{
    abstract class RequestDurationLoggingMessageHandler : Aspose.Html.Net.MessageHandler
    {
        private static readonly ConcurrentDictionary<string, Stopwatch> _timers = new ConcurrentDictionary<string, Stopwatch>();

        protected void StartTimer(Aspose.Html.Url url)
        {
            var key = url.ToString();
            var sw = new Stopwatch();
            sw.Start();
            _timers[key] = sw;
        }

        protected TimeSpan StopTimer(Aspose.Html.Url url)
        {
            var key = url.ToString();
            if (_timers.TryRemove(key, out var sw))
            {
                sw.Stop();
                return sw.Elapsed;
            }
            return TimeSpan.Zero;
        }
    }

    class StartRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            StartTimer(context.Request.RequestUri);
            Next(context);
        }
    }

    class StopRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            TimeSpan duration = StopTimer(context.Request.RequestUri);
            Debug.WriteLine($"Elapsed: {duration:g}, resource: {context.Request.RequestUri.Pathname}");
            Next(context);
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                var configuration = new Aspose.Html.Configuration();
                var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
                networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());

                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                var document = new Aspose.Html.HTMLDocument(htmlContent, configuration);

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}