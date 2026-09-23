// Use Parallel.ForEach to process multiple pages concurrently while respecting thread safety.

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Image;
using Aspose.Html.Converters;

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
    static void Main()
    {
        try
        {
            // Prepare sample HTML files
            var inputPaths = new List<string> { "page1.html", "page2.html", "page3.html" };
            string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, sampleHtml);
                }
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            // Configure network with timing handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new StartHandler());
            network.MessageHandlers.Add(new StopHandler());

            // Process pages concurrently
            Parallel.ForEach(inputPaths, inputPath =>
            {
                string htmlContent = File.ReadAllText(inputPath);
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");
                ImageSaveOptions options = new ImageSaveOptions(ImageFormat.Jpeg);
                Aspose.Html.Converters.Converter.ConvertHTML(htmlContent, options, outputPath);
                Console.WriteLine("Converted " + inputPath + " to " + outputPath);
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}