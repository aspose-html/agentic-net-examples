// Log download start and completion timestamps to a log file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);

            string logPath = Path.Combine(dataDir, "download_log.txt");
            string outputPdfPath = Path.Combine(dataDir, "output.pdf");
            string url = "https://example.com";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggerMessageHandler(logPath));

            System.Diagnostics.Stopwatch conversionTimer = System.Diagnostics.Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
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

public sealed class TimeLoggerMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;

    public TimeLoggerMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine($"Start: {startTime:O} | Request: {context.Request.RequestUri}");
        }

        Next(context);

        DateTime endTime = DateTime.UtcNow;
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine($"End: {endTime:O} | Request: {context.Request.RequestUri}");
            writer.WriteLine(new string('-', 40));
        }
    }
}