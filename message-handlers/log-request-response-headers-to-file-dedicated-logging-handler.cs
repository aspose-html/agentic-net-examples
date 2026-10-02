// Log request and response headers to a file via a dedicated logging handler.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFile;
    public LoggingHandler(string logFilePath)
    {
        _logFile = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(_logFile, true))
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
    public static void Main(string[] args)
    {
        try
        {
            string logPath = "log.txt";
            string outputPath = "output.html";
            string htmlContent = "<!DOCTYPE html><html><body><h1>Hello World</h1></body></html>";

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LoggingHandler(logPath));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank", configuration))
            {
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}