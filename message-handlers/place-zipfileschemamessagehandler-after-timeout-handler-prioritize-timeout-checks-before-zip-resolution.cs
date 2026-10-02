// Place ZipFileSchemaMessageHandler after the timeout handler to prioritize timeout checks before ZIP resolution.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html.Rendering.Pdf;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public sealed class ZipFileSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Custom ZIP schema handling logic could be placed here.
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "Extracted");
            System.IO.Directory.CreateDirectory(extractDir);

            // Extract HTML files from ZIP
            using (FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                        {
                            System.IO.Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the first HTML file
            string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");
            }

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Add handlers: timeout first, then ZIP schema handler
            network.MessageHandlers.Add(new TimeoutHandler());
            network.MessageHandlers.Add(new ZipFileSchemaMessageHandler());

            // Load document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice("output.pdf"))
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