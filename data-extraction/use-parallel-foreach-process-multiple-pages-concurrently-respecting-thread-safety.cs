// Use Parallel.ForEach to process multiple pages concurrently while respecting thread safety.

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

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
        Console.WriteLine("Request to " + context.Request.RequestUri + " took " + duration.TotalMilliseconds + " ms");
    }
}

class Program
{
    private static int fileCounter = 0;

    static void Main(string[] args)
    {
        try
        {
            // Sample URLs to process
            List<string> urls = new List<string>
            {
                "https://example.com",
                "https://example.org"
            };

            // Configure Aspose.HTML with custom network handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new StartHandler());
            network.MessageHandlers.Add(new StopHandler());

            // Process each URL in parallel
            Parallel.ForEach(urls, url =>
            {
                // Create HTML document from URL using the shared configuration
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
                {
                    // Generate a unique output file name
                    int index = Interlocked.Increment(ref fileCounter);
                    string outputFileName = "output_" + index + ".html";
                    string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

                    // Save the document to disk
                    document.Save(outputPath);
                    Console.WriteLine("Saved " + url + " to " + outputPath);
                }
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}