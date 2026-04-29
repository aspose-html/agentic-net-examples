// Add start and stop logging handlers around each network request to produce detailed performance reports per document.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputFile = "sample.html";
            string inputPath = System.IO.Path.Combine(dataDir, inputFile);
            string outputPath = "output.html";

            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new RequestStartHandler());
            networkService.MessageHandlers.Add(new RequestStopHandler());

            using (HTMLDocument document = new HTMLDocument(inputPath, configuration))
            {
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

abstract class RequestTimingBaseHandler : Aspose.Html.Net.MessageHandler
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

class RequestStartHandler : RequestTimingBaseHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

class RequestStopHandler : RequestTimingBaseHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        TimeSpan duration = StopTimer(context.Request.RequestUri);
        Console.WriteLine($"Request to {context.Request.RequestUri} took {duration.TotalMilliseconds} ms");
    }
}