// Configure the message handler order so Zip File Schema Message Handler runs before any logging handlers for accurate timing.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
            string outputPdfPath = "output.pdf";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from zip
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
                        {
                            Directory.CreateDirectory(entryDir);
                        }
                        ZipFileExtensions.ExtractToFile(entry, entryPath, true);
                    }
                }
            }

            // Locate the first HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");
            }
            string htmlPath = htmlFiles[0];

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Add timing handler before logging handlers
            network.MessageHandlers.Insert(0, new TimingHandler());
            network.MessageHandlers.Add(new LogHandler());

            // Convert HTML to PDF
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            using (PdfDevice device = new PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Timing handler to measure request duration
public sealed class TimingHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Stopwatch timer = Stopwatch.StartNew();
        Next(context);
        timer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + timer.ElapsedMilliseconds + " ms");
    }
}

// Simple logging handler
public sealed class LogHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}