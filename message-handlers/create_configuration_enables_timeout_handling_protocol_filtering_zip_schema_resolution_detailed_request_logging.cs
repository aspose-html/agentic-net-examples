// Create a configuration that enables timeout handling, protocol filtering, ZIP schema resolution, and detailed request logging.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
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

            // Locate the first HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            string htmlPath = htmlFiles[0];
            string outputPath = "output.pdf";

            // Configure network service with handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new LogHandler());
            network.MessageHandlers.Add(new TimeoutHandler());
            network.MessageHandlers.Add(new ProtocolHandler());

            // Load document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("Error: " + ex.Message);
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

// Protocol filtering (allow only HTTP/HTTPS)
public sealed class ProtocolHandler : Aspose.Html.Net.MessageHandler
{
    public ProtocolHandler()
    {
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("http"));
        Filters.Add(new Aspose.Html.Net.MessageFilters.ProtocolMessageFilter("https"));
    }

    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
    }
}