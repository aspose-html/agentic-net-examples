// Place ZipFileSchemaMessageHandler after the timeout handler to prioritize timeout checks before ZIP resolution.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

class ZipFileSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // No custom logic, just pass through
        Next(context);
    }
}

class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
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

            // Find the first HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            string htmlPath = htmlFiles[0];
            string outputPath = "output.pdf";

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            INetworkService network = configuration.GetService<INetworkService>();

            // Add handlers: timeout first, then ZIP schema handler
            network.MessageHandlers.Add(new TimeoutHandler());
            network.MessageHandlers.Add(new ZipFileSchemaMessageHandler());

            // Load document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (PdfDevice device = new PdfDevice(outputPath))
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