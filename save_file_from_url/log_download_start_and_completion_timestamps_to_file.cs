// Log download start and completion timestamps to a log file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;

public sealed class TimingHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        DateTime startTime = DateTime.UtcNow;
        Next(context);
        DateTime endTime = DateTime.UtcNow;
        TimeSpan elapsed = endTime - startTime;
        System.Diagnostics.Debug.WriteLine("Request: " + context.Request.RequestUri);
        System.Diagnostics.Debug.WriteLine("Start: " + startTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("End: " + endTime.ToString("O"));
        System.Diagnostics.Debug.WriteLine("Elapsed: " + elapsed.TotalMilliseconds + " ms");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "download.log";
            string htmlPath = "sample.html";

            using (StreamWriter logWriter = new StreamWriter(logPath, true))
            {
                // Log download start timestamp
                logWriter.WriteLine($"Download start: {DateTime.UtcNow:O}");

                // Configure Aspose.HTML with the timing handler
                Configuration configuration = new Configuration();
                INetworkService networkService = configuration.GetService<INetworkService>();
                networkService.MessageHandlers.Add(new TimingHandler());

                // Load the HTML document (download)
                HTMLDocument document = new HTMLDocument(htmlPath, configuration);

                // Log download completion timestamp
                logWriter.WriteLine($"Download completed: {DateTime.UtcNow:O}");

                // Optional: save the loaded document to verify processing
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}