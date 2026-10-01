// Log download start and completion timestamps to a log file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

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
            writer.WriteLine("Start: " + startTime.ToString("o") + " | URI: " + context.Request.RequestUri);
        }
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("End: " + endTime.ToString("o") + " | URI: " + context.Request.RequestUri);
            writer.WriteLine(new string('-', 40));
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string logPath = Path.Combine(Directory.GetCurrentDirectory(), "download_log.txt");
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggerMessageHandler(logPath));

            string url = "https://example.com";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}