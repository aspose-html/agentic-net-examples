// Place ZipFileSchemaMessageHandler after the timeout handler to prioritize timeout checks before ZIP resolution.

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
        // Set request timeout (e.g., 30 seconds)
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Path to the ZIP archive containing HTML files
            string zipPath = "input.zip";

            // Directory where the ZIP contents will be extracted
            string extractDirectory = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
            Directory.CreateDirectory(extractDirectory);

            // Extract only .html/.htm files from the ZIP archive
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

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Create configuration and register the timeout handler as the first handler
            Configuration configuration = new Configuration();
            INetworkService networkService = configuration.GetService<INetworkService>();
            networkService.MessageHandlers.Insert(0, new TimeoutHandler());

            // Output PDF path
            string outputPath = "output.pdf";

            // Load the HTML document with the configured timeout handler and render to PDF
            using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
            using (PdfDevice device = new PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}