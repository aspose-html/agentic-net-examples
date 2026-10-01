// Add start and stop logging handlers around each network request to produce detailed performance reports per document.

namespace AsposeHtmlLoggingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Prepare sample HTML file
                string dataDir = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data");
                System.IO.Directory.CreateDirectory(dataDir);
                string inputPath = System.IO.Path.Combine(dataDir, "sample.html");
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>");
                }

                // Configure Aspose.HTML with network handlers
                var configuration = new Aspose.Html.Configuration();
                var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Add(new StartHandler());
                networkService.MessageHandlers.Add(new StopHandler());

                // Load and save document
                var document = new Aspose.Html.HTMLDocument(inputPath, configuration);
                string outputPath = System.IO.Path.Combine(dataDir, "output.html");
                document.Save(outputPath);
                System.Console.WriteLine("Document saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Base handler with timer logic
    abstract class BaseHandler : Aspose.Html.Net.MessageHandler
    {
        protected static readonly System.Collections.Concurrent.ConcurrentDictionary<Aspose.Html.Url, System.Diagnostics.Stopwatch> timers =
            new System.Collections.Concurrent.ConcurrentDictionary<Aspose.Html.Url, System.Diagnostics.Stopwatch>();

        protected void StartTimer(Aspose.Html.Url url)
        {
            timers[url] = System.Diagnostics.Stopwatch.StartNew();
        }

        protected System.TimeSpan StopTimer(Aspose.Html.Url url)
        {
            if (timers.TryRemove(url, out System.Diagnostics.Stopwatch sw))
            {
                sw.Stop();
                return sw.Elapsed;
            }
            return System.TimeSpan.Zero;
        }
    }

    // Handler to start timing before request
    class StartHandler : BaseHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            StartTimer(context.Request.RequestUri);
            Next(context);
        }
    }

    // Handler to stop timing after response
    class StopHandler : BaseHandler
    {
        public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
        {
            Next(context);
            System.TimeSpan duration = StopTimer(context.Request.RequestUri);
            System.Console.WriteLine("Request to " + context.Request.RequestUri + " took " + duration.TotalMilliseconds + " ms");
        }
    }
}