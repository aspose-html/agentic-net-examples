// Add start and stop logging handlers around each network request to produce detailed performance reports per document.

using System;
using System.IO;
using System.Collections.Concurrent;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public abstract class BaseHandler : MessageHandler
{
    protected static readonly ConcurrentDictionary<Url, System.Diagnostics.Stopwatch> timers = new ConcurrentDictionary<Url, System.Diagnostics.Stopwatch>();

    protected void StartTimer(Url url)
    {
        timers[url] = System.Diagnostics.Stopwatch.StartNew();
    }

    protected System.TimeSpan StopTimer(Url url)
    {
        if (timers.TryRemove(url, out System.Diagnostics.Stopwatch sw))
        {
            sw.Stop();
            return sw.Elapsed;
        }
        return System.TimeSpan.Zero;
    }
}

public class StartHandler : BaseHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        StartTimer(context.Request.RequestUri);
        Next(context);
    }
}

public class StopHandler : BaseHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        System.TimeSpan duration = StopTimer(context.Request.RequestUri);
        System.Console.WriteLine("Request to " + context.Request.RequestUri + " took " + duration.TotalMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Prepare sample HTML file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string htmlPath = Path.Combine(dataDir, "sample.html");
            File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Configure Aspose.HTML with network handlers
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new StartHandler());
            networkService.MessageHandlers.Add(new StopHandler());

            // Load document with configuration
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Save the document to verify loading
                string outputPath = Path.Combine(dataDir, "output.html");
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