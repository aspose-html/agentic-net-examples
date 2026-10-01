// Create a configuration that includes both start and stop duration logging handlers for detailed performance metrics.

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using Aspose.Html.Net;

abstract class BaseHandler : Aspose.Html.Net.MessageHandler
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

class StartHandler : BaseHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

class StopHandler : BaseHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        TimeSpan duration = StopTimer(context.Request.RequestUri);
        Console.WriteLine("Elapsed: " + duration.TotalMilliseconds + " ms | " + context.Request.RequestUri);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new StartHandler());
            network.MessageHandlers.Add(new StopHandler());

            string htmlContent = "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, configuration))
            {
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