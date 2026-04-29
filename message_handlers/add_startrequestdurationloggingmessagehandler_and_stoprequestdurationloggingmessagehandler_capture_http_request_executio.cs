// Add StartRequestDurationLoggingMessageHandler and StopRequestDurationLoggingMessageHandler to capture HTTP request execution times.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

abstract class RequestDurationLoggingMessageHandler : MessageHandler
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

class StartRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

class StopRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        TimeSpan duration = StopTimer(context.Request.RequestUri);
        Debug.WriteLine($"Elapsed: {duration:g}, resource: {context.Request.RequestUri.Pathname}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and register the custom handlers
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());

            // Load an HTML document to trigger network requests
            string address = "https://example.com";
            using HTMLDocument document = new HTMLDocument(address, configuration);

            // Optionally, perform further processing with the document here
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}