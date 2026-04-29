// Develop a logging provider that writes conversion details to both console and a rotating log file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingMessageHandler : MessageHandler
{
    private readonly string _logFilePath;
    public LoggingMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            string requestInfo = $"Request URI: {context.Request.RequestUri}";
            Console.WriteLine(requestInfo);
            writer.WriteLine(requestInfo);
            string requestHeaders = $"Request Headers: {Convert.ToString(context.Request.Headers)}";
            Console.WriteLine(requestHeaders);
            writer.WriteLine(requestHeaders);
        }
        Next(context);
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            string responseInfo = $"Response Status: {context.Response.StatusCode}";
            Console.WriteLine(responseInfo);
            writer.WriteLine(responseInfo);
            string responseHeaders = $"Response Headers: {Convert.ToString(context.Response.Headers)}";
            Console.WriteLine(responseHeaders);
            writer.WriteLine(responseHeaders);
            writer.WriteLine(new string('-', 40));
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "conversion.log";
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new LoggingMessageHandler(logPath));
            string sourcePath = "input.html";
            string outputPath = "output.pdf";
            using (HTMLDocument document = new HTMLDocument(sourcePath, configuration))
            {
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}