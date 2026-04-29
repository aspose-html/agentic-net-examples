// Configure the message handler order so ZipFileSchemaMessageHandler runs before any logging handlers for accurate timing.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Services;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;

class LogHandler : MessageHandler
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
            string zipPath = "input.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "extracted");
            Directory.CreateDirectory(extractDir);
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            Configuration configuration = new Configuration();
            INetworkService network = configuration.GetService<INetworkService>();
            network.MessageHandlers.Add(new LogHandler());

            string htmlPath = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories)[0];
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                string outputPath = "output.pdf";
                PdfDevice device = new PdfDevice(outputPath);
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}