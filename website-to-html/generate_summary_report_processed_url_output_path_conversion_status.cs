// Generate a summary report listing each processed URL, output path, and conversion status.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        try
        {
            // Paths and literals
            string inputHtml = "sample.html";
            string outputHtml = "output.html";
            string resourceDirectory = "resources";
            string csvPath = "resources.csv";
            string zipPath = "sample.zip";
            string extractDirectory = "extracted";
            string outputPdfPath = "output.pdf";

            // Ensure directories exist
            Directory.CreateDirectory(resourceDirectory);
            Directory.CreateDirectory(extractDirectory);

            // Create a minimal HTML file if it does not exist
            if (!File.Exists(inputHtml))
            {
                File.WriteAllText(inputHtml, "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello Aspose.HTML</h1></body></html>");
            }

            // Load HTML document
            var document = new Aspose.Html.HTMLDocument(inputHtml);

            // Resource handler to capture saved resources
            var resourceHandler = new MyResourceHandler(resourceDirectory);
            var options = new Aspose.Html.Saving.HTMLSaveOptions();

            // Save document and resources
            document.Save(resourceHandler, options);

            // Write resources information to CSV
            using (var csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("Type,URL,LocalPath");
                foreach (var resource in resourceHandler.Resources)
                {
                    string type = resource.MimeType != null ? resource.MimeType.ToString() : "unknown";
                    string url = resource.OriginalUrl != null ? resource.OriginalUrl.ToString() : string.Empty;
                    string localPath = resource.OutputUrl != null ? resource.OutputUrl.ToString() : string.Empty;
                    csvWriter.WriteLine($"{type},{url},{localPath}");
                }
            }

            // Save the document to a separate HTML file
            document.Save(outputHtml);

            // Create a ZIP archive containing the HTML file
            using (var zipStream = File.Open(zipPath, FileMode.Create))
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                var entry = archive.CreateEntry(Path.GetFileName(inputHtml));
                using (var entryStream = entry.Open())
                using (var fileStream = File.OpenRead(inputHtml))
                {
                    fileStream.CopyTo(entryStream);
                }
            }

            // Extract HTML files from the ZIP archive
            using (var zipStream = File.OpenRead(zipPath))
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
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

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure network service with a custom message handler
            var configuration = new Aspose.Html.Configuration();
            var networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new MyMessageHandler());

            // Convert the extracted HTML to PDF and measure time
            var conversionTimer = Stopwatch.StartNew();
            using (var doc = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                doc.RenderTo(device);
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

// Custom resource handler that records saved resources
class MyResourceHandler : Aspose.Html.Saving.ResourceHandlers.FileSystemResourceHandler
{
    public List<Aspose.Html.Saving.Resource> Resources = new List<Aspose.Html.Saving.Resource>();

    public MyResourceHandler(string directory) : base(directory) { }

    public override void HandleResource(Aspose.Html.Saving.Resource resource, Aspose.Html.Saving.ResourceHandlingContext context)
    {
        Resources.Add(resource);
        base.HandleResource(resource, context);
    }
}

// Custom network message handler to log request duration
public sealed class MyMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        var requestTimer = Stopwatch.StartNew();
        Next(context);
        requestTimer.Stop();
        Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}