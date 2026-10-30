// Insert a logging handler at the beginning of the pipeline to capture request details.

using System;
using System.IO;

public sealed class RequestLoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string logFilePath;
    public RequestLoggingMessageHandler(string logFilePath)
    {
        this.logFilePath = logFilePath;
    }
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        using (StreamWriter writer = new StreamWriter(this.logFilePath, true))
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
            string logPath = "request_log.txt";
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a minimal sample HTML file
            File.WriteAllText(inputPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");

            // Configure Aspose.HTML and insert the logging handler at the beginning of the pipeline
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new RequestLoggingMessageHandler(logPath));

            // Load the HTML document using the configuration with the logging handler in place
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, configuration))
            {
                document.Save(outputPath);
            }

            Console.WriteLine("Document saved to: " + outputPath);
            Console.WriteLine("Request log written to: " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}