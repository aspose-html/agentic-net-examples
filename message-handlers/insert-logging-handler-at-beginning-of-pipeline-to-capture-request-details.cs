// Insert a logging handler at the beginning of the pipeline to capture request details.

using System;
using System.IO;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

public sealed class RequestLoggingHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    public RequestLoggingHandler(string logFilePath)
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
            // Define paths
            string dataDir = Directory.GetCurrentDirectory();
            string htmlFilePath = Path.Combine(dataDir, "sample.html");
            string outputPath = Path.Combine(dataDir, "output.html");
            string logPath = Path.Combine(dataDir, "request_log.txt");

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(htmlFilePath))
            {
                File.WriteAllText(htmlFilePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            // Configure Aspose.HTML and add logging handler at the beginning of the pipeline
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            Aspose.Html.Net.MessageHandlerCollection handlers = networkService.MessageHandlers;
            handlers.Insert(0, new RequestLoggingHandler(logPath));

            // Load the HTML document using the configuration
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath, configuration))
            {
                // Save the document to the output path
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to: " + outputPath);
            Console.WriteLine("Request log saved to: " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}