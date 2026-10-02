// Log detailed conversion progress and errors to a file for troubleshooting batch operations.

using System;
using System.IO;
using System.Diagnostics;

public sealed class NetworkLogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch requestTimer = Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputPdf";
            string logPath = "conversion.log";

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);
            // Ensure log file exists
            File.WriteAllText(logPath, $"Conversion started at {DateTime.Now}{Environment.NewLine}");

            // Create a sample HTML file if none exist
            string[] htmlFiles = Directory.GetFiles(inputFolder, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                htmlFiles = new string[] { samplePath };
            }
            if (htmlFiles.Length == 0)
            {
                htmlFiles = Directory.GetFiles(inputFolder, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML files found for conversion.");

            int total = htmlFiles.Length;
            int successCount = 0;

            for (int i = 0; i < total; i++)
            {
                string htmlPath = htmlFiles[i];
                string pdfPath = Path.Combine(outputFolder, Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");
                try
                {
                    File.AppendAllText(logPath, $"[{DateTime.Now}] Starting conversion: {htmlPath}{Environment.NewLine}");

                    Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                    Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                    networkService.MessageHandlers.Add(new NetworkLogHandler());

                    Stopwatch conversionTimer = Stopwatch.StartNew();

                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                    using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
                    {
                        document.RenderTo(device);
                    }

                    conversionTimer.Stop();
                    File.AppendAllText(logPath, $"[{DateTime.Now}] Successfully converted to {pdfPath} in {conversionTimer.Elapsed.TotalSeconds:F2} seconds.{Environment.NewLine}");
                    Console.WriteLine($"Converted {i + 1}/{total} ({(i + 1) * 100 / total}%)");
                    successCount++;
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logPath, $"[{DateTime.Now}] Error converting {htmlPath}: {ex.Message}{Environment.NewLine}");
                    Console.WriteLine($"Error converting file {Path.GetFileName(htmlPath)}: {ex.Message}");
                }
            }

            File.AppendAllText(logPath, $"Conversion completed at {DateTime.Now}. Success: {successCount}/{total}{Environment.NewLine}");
            Console.WriteLine($"Batch conversion finished. {successCount} of {total} files converted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Fatal error: " + ex.Message);
        }
    }
}