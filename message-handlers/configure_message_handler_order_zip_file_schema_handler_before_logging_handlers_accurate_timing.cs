// Configure the message handler order so Zip File Schema Message Handler runs before any logging handlers for accurate timing.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
            string extractDir = Path.Combine(Path.GetTempPath(), "extracted");
            string outputPdfPath = Path.Combine(Path.GetTempPath(), "output.pdf");

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Create a sample zip with a simple HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("index.html");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.WriteLine("<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                    }
                }
            }

            // Extract HTML files from the zip
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        string entryDir = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryDir))
                            Directory.CreateDirectory(entryDir);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the first HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();

            // Add ZipFileSchemaMessageHandler (timing) before any logging handlers
            networkService.MessageHandlers.Insert(0, new ZipFileSchemaMessageHandler());

            // Add a logging handler
            networkService.MessageHandlers.Add(new LoggingHandler());

            // Convert HTML to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully. PDF saved to: " + outputPdfPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Timing handler that measures request duration
public sealed class ZipFileSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch timer = Stopwatch.StartNew();
        Next(context);
        timer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + timer.ElapsedMilliseconds + " ms");
    }
}

// Simple logging handler
public sealed class LoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine("Logged: " + context.Request.RequestUri + " | Status: " + context.Response.StatusCode);
    }
}