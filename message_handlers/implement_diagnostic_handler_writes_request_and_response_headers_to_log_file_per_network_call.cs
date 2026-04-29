// Implement a diagnostic handler that writes request and response headers to a log file for each network call.

using System;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;

public sealed class DiagnosticHandler : MessageHandler
{
    private readonly string _logFilePath;
    public DiagnosticHandler(string logFilePath)
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
            // Paths for log, input HTML, and output HTML
            string logPath = "network.log";
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create configuration and register the diagnostic handler
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new DiagnosticHandler(logPath));

            // Load the HTML document with the configuration and save it
            using (HTMLDocument document = new HTMLDocument(inputPath, configuration))
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