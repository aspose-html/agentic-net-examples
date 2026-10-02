// Combine ZipFileSchemaMessageHandler with NetworkDisabledMessageHandler to safely load HTML from ZIP while restricting protocols.

using System;
using System.IO;
using System.IO.Compression;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase))
            throw new System.InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Prepare sample ZIP with an HTML file
            string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
            using (FileStream zipStream = new FileStream(zipPath, FileMode.Create, FileAccess.ReadWrite))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
            {
                ZipArchiveEntry entry = archive.CreateEntry("index.html");
                using (Stream entryStream = entry.Open())
                using (StreamWriter writer = new StreamWriter(entryStream))
                {
                    writer.Write("<html><body><h1>Hello from ZIP</h1></body></html>");
                }
            }

            // Extract HTML files from ZIP
            string extractDirectory = Path.Combine(Path.GetTempPath(), "extractedHtml");
            Directory.CreateDirectory(extractDirectory);
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
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

            // Configure Aspose.HTML with custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Render HTML to PDF
            string outputPath = Path.Combine(Path.GetTempPath(), "output.pdf");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}