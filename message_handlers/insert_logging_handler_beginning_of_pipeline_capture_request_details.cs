// Insert a logging handler at the beginning of the pipeline to capture request details.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class LoggingHandler : MessageHandler
{
    private readonly string logFilePath;
    public LoggingHandler(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }
    public override void Invoke(INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
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

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "request_log.txt";
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new LoggingHandler(logPath));

            using (HTMLDocument document = new HTMLDocument("input.html", configuration))
            {
                document.Save("output.html");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}