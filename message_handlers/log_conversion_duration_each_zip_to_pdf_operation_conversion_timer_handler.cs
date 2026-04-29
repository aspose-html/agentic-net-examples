// Log conversion duration for each ZIP‑to‑PDF operation with a conversion‑timer handler.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class RequestLoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch requestTimer = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = @"C:\input.zip";
            string extractDir = @"C:\extracted";
            string outputPdfPath = @"C:\output.pdf";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from ZIP
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        string entryFolder = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML and add request logging handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Add(new RequestLoggingHandler());

            // Measure conversion time
            System.Diagnostics.Stopwatch conversionTimer = System.Diagnostics.Stopwatch.StartNew();

            // Convert HTML to PDF
            using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
            using (PdfDevice device = new PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}