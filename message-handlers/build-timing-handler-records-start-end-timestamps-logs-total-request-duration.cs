// Build a timing handler that records start and end timestamps and logs total request duration.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html.Net;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Services;

abstract class RequestDurationLoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    private static readonly ConcurrentDictionary<Aspose.Html.Url, Stopwatch> _timers = new ConcurrentDictionary<Aspose.Html.Url, Stopwatch>();

    protected void StartTimer(Aspose.Html.Url url)
    {
        var sw = new Stopwatch();
        sw.Start();
        _timers[url] = sw;
    }

    protected TimeSpan StopTimer(Aspose.Html.Url url)
    {
        if (_timers.TryRemove(url, out var sw))
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
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add timing handlers
            networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());

            // Load a sample HTML document
            string url = "https://example.com";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration);

            // Output document title to verify loading
            Debug.WriteLine("Document title: " + document.Title);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}