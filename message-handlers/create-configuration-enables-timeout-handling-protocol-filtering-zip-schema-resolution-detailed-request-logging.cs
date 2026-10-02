// Create a configuration that enables timeout handling, protocol filtering, ZIP schema resolution, and detailed request logging.

using System;
using System.IO;
using System.IO.Compression;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML and ZIP
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExample");
            Directory.CreateDirectory(tempDir);

            string htmlContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
            string htmlFileName = "sample.html";
            string htmlFilePath = Path.Combine(tempDir, htmlFileName);
            File.WriteAllText(htmlFilePath, htmlContent);

            string zipPath = Path.Combine(tempDir, "sample.zip");
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                ZipArchiveEntry entry = archive.CreateEntry(htmlFileName);
                using (Stream entryStream = entry.Open())
                using (StreamWriter writer = new StreamWriter(entryStream))
                {
                    writer.Write(htmlContent);
                }
            }

            // Extract ZIP
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
            Directory.CreateDirectory(extractDir);
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

            // Locate HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new TimeoutHandler());
            network.MessageHandlers.Add(new ProtocolHandler());
            network.MessageHandlers.Insert(0, new LogHandler());

            // Load document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            {
                string outputPath = Path.Combine(extractDir, "output.pdf");
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }
                Console.WriteLine("PDF generated at: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Timeout handling
public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

// Detailed request logging
public sealed class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

// Protocol filtering (allow only http and https)
public sealed class ProtocolHandler : Aspose.Html.Net.MessageHandler
{
    public ProtocolHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http,https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}