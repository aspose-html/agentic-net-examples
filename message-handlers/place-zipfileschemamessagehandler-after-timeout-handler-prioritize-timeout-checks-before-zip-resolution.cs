// Place ZipFileSchemaMessageHandler after the timeout handler to prioritize timeout checks before ZIP resolution.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = System.TimeSpan.FromSeconds(30);
        Next(context);
    }
}

class ZipFileSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Placeholder for ZIP schema handling logic
        Next(context);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "ExtractedHtml");
            System.IO.Directory.CreateDirectory(extractDir);

            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            System.IO.Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.");

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new TimeoutHandler());
            network.MessageHandlers.Add(new ZipFileSchemaMessageHandler());

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