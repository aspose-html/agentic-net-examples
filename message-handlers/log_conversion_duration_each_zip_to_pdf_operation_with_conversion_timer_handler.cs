// Log conversion duration for each ZIP‑to‑PDF operation with a conversion‑timer handler.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using Aspose.Html.Net;

public sealed class RequestTimerHandler : Aspose.Html.Net.MessageHandler
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
            string zipPath = "sample.zip";
            string extractDirectory = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
            string outputPdfPath = "output.pdf";

            Directory.CreateDirectory(extractDirectory);

            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDirectory, entry.FullName);
                        string entryFolder = Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RequestTimerHandler());

            Stopwatch conversionTimer = Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
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