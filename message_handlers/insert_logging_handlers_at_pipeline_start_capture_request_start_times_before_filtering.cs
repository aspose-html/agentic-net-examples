// Insert logging handlers at the beginning of the pipeline to capture request start times before any filtering.

using System;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;

class TimeLoggerMessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + "ms");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            var handlers = networkService.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());

            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            string documentPath = System.IO.Path.Combine(dataDir, "sample.html");
            using (var document = new Aspose.Html.HTMLDocument(documentPath, configuration))
            {
                Console.WriteLine("HTML document loaded successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}