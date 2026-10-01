// Add StartRequestDurationLoggingMessageHandler and StopRequestDurationLoggingMessageHandler to capture HTTP request execution times.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

abstract class RequestDurationLoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    protected static readonly ConcurrentDictionary<Aspose.Html.Url, Stopwatch> timers = new ConcurrentDictionary<Aspose.Html.Url, Stopwatch>();

    protected void StartTimer(Aspose.Html.Url url)
    {
        timers[url] = Stopwatch.StartNew();
    }

    protected TimeSpan StopTimer(Aspose.Html.Url url)
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
    static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine($"Document saved to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}