// Log request and response headers to a file via a dedicated logging handler.

using System;
using System.IO;
using Aspose.Html.Net;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

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

class Program
{
    static void Main()
    {
        try
        {
            string logPath = "network.log";
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LoggingHandler(logPath));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to " + outputPath);
            Console.WriteLine("Network log written to " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}