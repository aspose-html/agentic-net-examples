// Log conversion parameters, including source path, target format, and duration, to a JSON file.

using System;
using System.IO;
using System.Diagnostics;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Net;

public sealed class LoggingMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch requestTimer = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        System.Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define paths
            string sourcePath = "sample.html";
            string outputPdfPath = "output.pdf";
            string jsonPath = "conversion_log.json";

            // Ensure sample HTML exists
            if (!System.IO.File.Exists(sourcePath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                System.IO.File.WriteAllText(sourcePath, sampleHtml);
            }

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new LoggingMessageHandler());

            // Conversion timer
            System.Diagnostics.Stopwatch conversionTimer = System.Diagnostics.Stopwatch.StartNew();

            // Load HTML document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            conversionTimer.Stop();

            // Log conversion parameters to JSON
            var log = new
            {
                SourcePath = System.IO.Path.GetFullPath(sourcePath),
                TargetFormat = "PDF",
                DurationSeconds = conversionTimer.Elapsed.TotalSeconds
            };

            string json = System.Text.Json.JsonSerializer.Serialize(log, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(jsonPath, json);

            System.Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
            System.Console.WriteLine("Log written to " + jsonPath);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}