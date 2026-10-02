// Log download start and completion timestamps to a log file.

using System;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories and files
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);

            string htmlPath = Path.Combine(dataDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            string logPath = Path.Combine(dataDir, "download.log");
            string outputPdfPath = Path.Combine(dataDir, "output.pdf");

            // Configure Aspose.HTML with custom message handler
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new TimeLoggerMessageHandler(logPath));

            // Load HTML document and render to PDF (triggers network operations)
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine($"Log written to: {logPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
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
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;

        using (var writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Start: " + startTime.ToString("O"));
            writer.WriteLine("End: " + endTime.ToString("O"));
            writer.WriteLine("Elapsed (ms): " + elapsed.TotalMilliseconds);
            writer.WriteLine(new string('-', 40));
        }
    }
}