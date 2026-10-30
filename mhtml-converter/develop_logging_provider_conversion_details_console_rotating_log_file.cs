// Develop a logging provider that writes conversion details to both console and a rotating log file.

using System;
using System.IO;
using Aspose.Html.Net;

public sealed class RotatingLogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    private const long MaxLogFileSize = 1 * 1024 * 1024; // 1 MB

    public RotatingLogMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    private void RotateLogIfNeeded()
    {
        try
        {
            if (File.Exists(_logFilePath))
            {
                var fileInfo = new FileInfo(_logFilePath);
                if (fileInfo.Length > MaxLogFileSize)
                {
                    string archivePath = _logFilePath + ".1";
                    if (File.Exists(archivePath))
                    {
                        File.Delete(archivePath);
                    }
                    File.Move(_logFilePath, archivePath);
                }
            }
        }
        catch
        {
            // Swallow any rotation errors to avoid breaking the main flow.
        }
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        RotateLogIfNeeded();

        string requestInfo = "Request URI: " + context.Request.RequestUri;
        string requestHeaders = "Request Headers: " + Convert.ToString(context.Request.Headers);
        string responseInfo = "Response Status: " + context.Response.StatusCode;
        string responseHeaders = "Response Headers: " + Convert.ToString(context.Response.Headers);
        string separator = new string('-', 40);

        // Write to console
        Console.WriteLine(requestInfo);
        Console.WriteLine(requestHeaders);
        Console.WriteLine(responseInfo);
        Console.WriteLine(responseHeaders);
        Console.WriteLine(separator);

        // Write to log file
        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            writer.WriteLine(requestInfo);
            writer.WriteLine(requestHeaders);
            Next(context);
            writer.WriteLine(responseInfo);
            writer.WriteLine(responseHeaders);
            writer.WriteLine(separator);
        }
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);

            string inputHtmlPath = Path.Combine(dataDir, "sample.html");
            string outputPdfPath = Path.Combine(dataDir, "output.pdf");
            string logPath = Path.Combine(dataDir, "conversion.log");

            // Create a minimal HTML file
            if (!File.Exists(inputHtmlPath))
            {
                File.WriteAllText(inputHtmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
            }

            // Configure Aspose.HTML with the custom logging handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RotatingLogMessageHandler(logPath));

            // Load the HTML document and save as PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputHtmlPath, configuration))
            {
                document.Save(outputPdfPath);
            }

            Console.WriteLine("Conversion completed successfully.");
            Console.WriteLine("Output PDF: " + outputPdfPath);
            Console.WriteLine("Log file: " + logPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}