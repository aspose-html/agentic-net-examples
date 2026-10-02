// Develop a logging provider that writes conversion details to both console and a rotating log file.

using System;
using System.IO;

public sealed class RotatingLogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logFilePath;
    private const long MaxFileSize = 1_048_576; // 1 MB

    public RotatingLogMessageHandler(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        RotateIfNeeded();

        using (StreamWriter writer = new StreamWriter(_logFilePath, true))
        {
            string requestInfo = "Request URI: " + context.Request.RequestUri;
            string requestHeaders = "Request Headers: " + Convert.ToString(context.Request.Headers);
            Console.WriteLine(requestInfo);
            Console.WriteLine(requestHeaders);
            writer.WriteLine(requestInfo);
            writer.WriteLine(requestHeaders);

            Next(context);

            string responseInfo = "Response Status: " + context.Response.StatusCode;
            string responseHeaders = "Response Headers: " + Convert.ToString(context.Response.Headers);
            Console.WriteLine(responseInfo);
            Console.WriteLine(responseHeaders);
            writer.WriteLine(responseInfo);
            writer.WriteLine(responseHeaders);
            writer.WriteLine(new string('-', 40));
        }
    }

    private void RotateIfNeeded()
    {
        if (File.Exists(_logFilePath) && new FileInfo(_logFilePath).Length > MaxFileSize)
        {
            string archivePath = _logFilePath + "." + DateTime.Now.ToString("yyyyMMddHHmmss");
            File.Move(_logFilePath, archivePath);
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

            string htmlPath = Path.Combine(dataDir, "sample.html");
            string outputPath = Path.Combine(dataDir, "output.pdf");
            string logPath = Path.Combine(dataDir, "conversion.log");

            if (!File.Exists(htmlPath))
            {
                File.WriteAllText(htmlPath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose HTML</h1></body></html>");
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RotatingLogMessageHandler(logPath));

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            Console.WriteLine("Conversion completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}