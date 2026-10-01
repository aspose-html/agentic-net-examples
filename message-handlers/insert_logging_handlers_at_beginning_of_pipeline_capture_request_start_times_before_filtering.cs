// Insert logging handlers at the beginning of the pipeline to capture request start times before any filtering.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;

public sealed class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri);
        Console.WriteLine("Time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = "Data";
            Directory.CreateDirectory(dataDir);
            string htmlPath = Path.Combine(dataDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<html><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = networkService.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());

            string outputPdfPath = Path.Combine(dataDir, "output.pdf");
            Stopwatch conversionTimer = Stopwatch.StartNew();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}