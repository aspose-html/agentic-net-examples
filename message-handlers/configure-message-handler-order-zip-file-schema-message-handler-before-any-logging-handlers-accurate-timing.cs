// Configure the message handler order so Zip File Schema Message Handler runs before any logging handlers for accurate timing.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class TimingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch requestTimer = System.Diagnostics.Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        System.Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ExtractedHtml");
            string outputPdfPath = "output.pdf";

            System.IO.Directory.CreateDirectory(extractDir);

            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            System.IO.Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Insert timing handler before any logging handlers
            network.MessageHandlers.Insert(0, new TimingHandler());
            network.MessageHandlers.Add(new LogHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}