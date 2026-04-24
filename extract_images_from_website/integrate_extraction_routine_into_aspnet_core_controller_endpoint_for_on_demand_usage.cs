// Integrate the extraction routine into an ASP.NET Core controller endpoint for on‑demand usage.

using System;
using System.Diagnostics;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;

public class TimeLoggerMessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        Debug.WriteLine($"Request: {context.Request.RequestUri}");
        Debug.WriteLine($"Time: {stopwatch.ElapsedMilliseconds}ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string htmlFile = "sample.html";
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService service = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = service.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());
            string documentPath = Path.Combine(dataDir, htmlFile);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(documentPath, configuration);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}