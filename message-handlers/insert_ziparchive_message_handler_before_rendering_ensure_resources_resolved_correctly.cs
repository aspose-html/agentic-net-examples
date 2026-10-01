// Insert ZipArchiveMessageHandler before rendering to ensure resources are resolved correctly.

using System;

class Program
{
    static void Main(string[] args)
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
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDir, entry.FullName);
                        System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(entryPath));
                        using (var entryStream = entry.Open())
                        using (var fileStream = System.IO.File.Create(entryPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Insert(0, new LogHandler());

            string htmlPath = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories)[0];
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string outputPath = "output.pdf";
                Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath);
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}