// Log request and response headers to a file via a dedicated logging handler.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingHandler : MessageHandler
{
    private readonly string _logFilePath;
    public LoggingHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(_logFilePath, true))
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

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "request_response.log";
            string sourceUrl = "https://example.com";
            string outputPath = "output.html";

            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new LoggingHandler(logPath));

            using (HTMLDocument document = new HTMLDocument(sourceUrl, configuration))
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