// Develop a logging provider that writes conversion details to both console and a rotating log file.

using System;

public sealed class RotatingLogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string logFilePath;
    private readonly long maxFileSize;

    public RotatingLogMessageHandler(string logFilePath, long maxFileSize)
    {
        this.logFilePath = logFilePath;
        this.maxFileSize = maxFileSize;
    }

    private void RotateIfNeeded()
    {
        try
        {
            if (System.IO.File.Exists(logFilePath))
            {
                var info = new System.IO.FileInfo(logFilePath);
                if (info.Length > maxFileSize)
                {
                    string archivePath = logFilePath + "." + System.DateTime.Now.ToString("yyyyMMddHHmmss");
                    System.IO.File.Move(logFilePath, archivePath);
                }
            }
        }
        catch
        {
            // Ignore rotation errors
        }
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        RotateIfNeeded();
        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(logFilePath, true))
        {
            string requestInfo = "Request URI: " + context.Request.RequestUri;
            System.Console.WriteLine(requestInfo);
            writer.WriteLine(requestInfo);

            string requestHeaders = "Request Headers: " + System.Convert.ToString(context.Request.Headers);
            System.Console.WriteLine(requestHeaders);
            writer.WriteLine(requestHeaders);

            Next(context);

            string responseStatus = "Response Status: " + context.Response.StatusCode;
            System.Console.WriteLine(responseStatus);
            writer.WriteLine(responseStatus);

            string responseHeaders = "Response Headers: " + System.Convert.ToString(context.Response.Headers);
            System.Console.WriteLine(responseHeaders);
            writer.WriteLine(responseHeaders);

            string separator = new string('-', 40);
            System.Console.WriteLine(separator);
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
            string dataDir = System.IO.Path.Combine(System.Environment.CurrentDirectory, "Data");
            System.IO.Directory.CreateDirectory(dataDir);

            string htmlPath = System.IO.Path.Combine(dataDir, "sample.html");
            System.IO.File.WriteAllText(htmlPath, "<html><body><h1>Hello Aspose.HTML</h1></body></html>");

            string outputPath = System.IO.Path.Combine(dataDir, "output.pdf");
            string logPath = System.IO.Path.Combine(dataDir, "conversion.log");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RotatingLogMessageHandler(logPath, 10 * 1024)); // 10 KB max size

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed. Log written to: " + logPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}