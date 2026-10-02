// Raise progress events after each resource is downloaded to report extraction status.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Threading;
using Aspose.Html.Net;

public sealed class ProgressMessageHandler : Aspose.Html.Net.MessageHandler
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
    public static void Main(string[] args)
    {
        try
        {
            // Prepare sample ZIP with an HTML file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            Directory.CreateDirectory(dataDir);
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1></body></html>";
            string htmlFilePath = Path.Combine(dataDir, "test.html");
            File.WriteAllText(htmlFilePath, htmlContent);
            string zipPath = Path.Combine(dataDir, "sample.zip");
            using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
            {
                ZipArchiveEntry entry = archive.CreateEntry("test.html");
                using (Stream entryStream = entry.Open())
                using (StreamWriter writer = new StreamWriter(entryStream))
                {
                    writer.Write(htmlContent);
                }
            }

            // Extraction settings
            string extractDirectory = Path.Combine(dataDir, "extracted");
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

            // Locate HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML with progress handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ProgressMessageHandler());

            // Convert to PDF
            string outputPdfPath = Path.Combine(dataDir, "output.pdf");
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