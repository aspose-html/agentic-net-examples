// Add StartRequestDurationLoggingMessageHandler and StopRequestDurationLoggingMessageHandler to capture HTTP request execution times.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            // Create configuration and obtain network service
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add request duration logging handlers
            networkService.MessageHandlers.Add(new StartRequestDurationLoggingMessageHandler());
            networkService.MessageHandlers.Add(new StopRequestDurationLoggingMessageHandler());

            // Sample HTML content
            string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
            Aspose.Html.Url baseUri = new Aspose.Html.Url("about:blank");

            // Load document with configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri, configuration))
            {
                // Save document to file
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine("Document saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Abstract base handler for timing
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

// Handler to start timing before request
class StartRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

// Handler to stop timing after request and log duration
class StopRequestDurationLoggingMessageHandler : RequestDurationLoggingMessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        TimeSpan duration = StopTimer(context.Request.RequestUri);
        Debug.WriteLine($"Elapsed: {duration:g}, resource: {context.Request.RequestUri.Pathname}");
        Next(context);
    }
}