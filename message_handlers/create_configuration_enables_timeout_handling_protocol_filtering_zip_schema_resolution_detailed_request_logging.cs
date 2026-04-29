// Create a configuration that enables timeout handling, protocol filtering, ZIP schema resolution, and detailed request logging.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class TimeoutHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public sealed class LocalOnlyGuardHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        string uri = context.Request.RequestUri?.ToString() ?? string.Empty;
        if (!string.IsNullOrEmpty(uri) && !uri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}

public sealed class LoggingHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDirectory = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
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

            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutHandler());
            networkService.MessageHandlers.Add(new LocalOnlyGuardHandler());
            networkService.MessageHandlers.Add(new LoggingHandler());

            using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
            using (PdfDevice device = new PdfDevice("output.pdf"))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}