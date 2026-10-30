// Insert logging handlers at the beginning of the pipeline to capture request start times before any filtering.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Data");
            System.IO.Directory.CreateDirectory(dataDir);
            string htmlPath = System.IO.Path.Combine(dataDir, "sample.html");
            if (!System.IO.File.Exists(htmlPath))
            {
                System.IO.File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>");
            }
            string outputPdfPath = System.IO.Path.Combine(dataDir, "output.pdf");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = networkService.MessageHandlers;
            handlers.Insert(0, new TimeLoggerMessageHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("Conversion completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}

sealed class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        stopwatch.Stop();
        System.Console.WriteLine("Request: " + context.Request.RequestUri + " | Time: " + stopwatch.ElapsedMilliseconds + " ms");
    }
}