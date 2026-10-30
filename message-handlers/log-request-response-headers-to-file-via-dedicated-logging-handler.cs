// Log request and response headers to a file via a dedicated logging handler.

using System;
using System.IO;

public sealed class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public LoggingHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine("Request URI: " + context.Request.RequestUri);
            writer.WriteLine("Request Headers: " + Convert.ToString(context.Request.Headers));
            Next(context);
            writer.WriteLine("Response Status: " + context.Response.StatusCode);
            writer.WriteLine("Response Headers: " + Convert.ToString(context.Response.Headers));
            writer.WriteLine(new string('-', 40));
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string logPath = "request_response_log.txt";
            string outputPath = "output.html";
            string url = "https://example.com";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LoggingHandler(logPath));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url, configuration))
            {
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to " + outputPath);
            Console.WriteLine("Request and response headers logged to " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}