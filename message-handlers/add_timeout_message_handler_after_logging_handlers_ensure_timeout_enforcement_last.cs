// Add a TimeoutMessageHandler after logging handlers to ensure timeout enforcement occurs last.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class TimeoutMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public abstract class RequestDurationLoggingMessageHandler : Aspose.Html.Net.MessageHandler
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

public class StartRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

public class StopRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        TimeSpan duration = StopTimer(context.Request.RequestUri);
        Console.WriteLine($"Elapsed: {duration.TotalMilliseconds} ms | {context.Request.RequestUri}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new TimeoutMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument("<html><body><h1>Hello World</h1></body></html>", configuration))
            {
                document.Save("output.html");
            }

            Console.WriteLine("Document saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}