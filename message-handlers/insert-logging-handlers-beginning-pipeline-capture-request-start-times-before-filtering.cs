// Insert logging handlers at the beginning of the pipeline to capture request start times before any filtering.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri);
        Console.WriteLine("Elapsed: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);

            string htmlPath = Path.Combine(dataDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1><img src=\"https://via.placeholder.com/150\" alt=\"Sample Image\"/></body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeLoggerMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(Path.Combine(dataDir, "output.pdf")))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}