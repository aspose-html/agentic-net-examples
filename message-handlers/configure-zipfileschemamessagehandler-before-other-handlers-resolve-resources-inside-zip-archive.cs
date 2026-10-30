// Configure ZipFileSchemaMessageHandler before other handlers to resolve resources inside a ZIP archive.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "HTMLFromZip");
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from the ZIP archive
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
                        {
                            Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
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

            // Insert ZipFileSchemaMessageHandler before other handlers
            network.MessageHandlers.Insert(0, new ZipFileSchemaMessageHandler());

            // Optional: add a simple logging handler
            network.MessageHandlers.Add(new LogHandler());

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                // Render to PDF
                string outputPath = Path.Combine(extractDir, "output.pdf");
                using (PdfDevice device = new PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF generated at: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom handler to resolve resources inside a ZIP archive (placeholder implementation)
class ZipFileSchemaMessageHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        // Placeholder: actual ZIP schema handling logic would go here
        Next(context);
    }
}

// Simple logging handler
class LogHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}