// Implement a diagnostic handler that writes request and response headers to a log file for each network call.

using System;

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public LogMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (var writer = new System.IO.StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Request Headers: " + System.Convert.ToString(context.Request.Headers));
            Next(context);
            writer.WriteLine("Response Status: " + context.Response.StatusCode);
            writer.WriteLine("Response Headers: " + System.Convert.ToString(context.Response.Headers));
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
            string logPath = "network_log.txt";
            string outputPath = "output.html";

            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LogMessageHandler(logPath));

            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";

            using (var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}