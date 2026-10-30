// Log detailed conversion progress and errors to a file for troubleshooting batch operations.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html.Net;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

public sealed class LogMessageHandler : Aspose.Html.Net.MessageHandler
{
    private readonly string _logPath;

    public LogMessageHandler(string logPath)
    {
        _logPath = logPath;
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch requestTimer = Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        string logEntry = $"[{DateTime.Now}] Request: {context.Request.RequestUri} | Status: {context.Response.StatusCode} | {requestTimer.ElapsedMilliseconds} ms";
        File.AppendAllText(_logPath, logEntry + Environment.NewLine);
    }
}

public class Program
{
    private static readonly string LogPath = "conversion.log";

    public static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input_html";
            string outputFolder = "output_pdf";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string[] existingHtml = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);
            if (existingHtml.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                File.WriteAllText(samplePath, sampleContent);
            }

            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);
            int total = htmlFiles.Length;
            int processed = 0;

            foreach (string htmlPath in htmlFiles)
            {
                try
                {
                    string fileName = Path.GetFileNameWithoutExtension(htmlPath);
                    string pdfPath = Path.Combine(outputFolder, fileName + ".pdf");

                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                    networkService.MessageHandlers.Add(new LogMessageHandler(LogPath));

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    {
                        Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                        Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                    }

                    processed++;
                    string successLog = $"[{DateTime.Now}] Converted: {Path.GetFileName(htmlPath)} -> {Path.GetFileName(pdfPath)} ({processed}/{total})";
                    File.AppendAllText(LogPath, successLog + Environment.NewLine);
                    Console.WriteLine(successLog);
                }
                catch (Exception ex)
                {
                    string errorLog = $"[{DateTime.Now}] Error converting {Path.GetFileName(htmlPath)}: {ex.Message}";
                    File.AppendAllText(LogPath, errorLog + Environment.NewLine);
                    Console.WriteLine(errorLog);
                }
            }

            string summary = $"[{DateTime.Now}] Conversion completed. Processed {processed} of {total} files.";
            File.AppendAllText(LogPath, summary + Environment.NewLine);
            Console.WriteLine(summary);
        }
        catch (Exception ex)
        {
            string fatalLog = $"[{DateTime.Now}] Fatal error: {ex.Message}";
            File.AppendAllText(LogPath, fatalLog + Environment.NewLine);
            Console.WriteLine(fatalLog);
        }
    }
}