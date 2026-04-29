// Insert ZipArchiveMessageHandler before rendering to ensure resources are resolved correctly.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Services;
using Aspose.Html.Net;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "input.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
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
            network.MessageHandlers.Add(new TimeoutHandler());
            string htmlPath = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories)[0];
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            {
                PdfDevice device = new PdfDevice("output.pdf");
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    class TimeoutHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(30);
            Next(context);
        }
    }
}