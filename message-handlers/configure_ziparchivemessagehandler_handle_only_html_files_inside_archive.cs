// Configure ZipArchiveMessageHandler to handle only .html files inside the archive.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample ZIP with an HTML file
            string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
            if (!File.Exists(zipPath))
            {
                using (FileStream zipToCreate = File.Open(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("sample.html");
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("<html><body><h1>Hello World from ZIP</h1></body></html>");
                    }
                }
            }

            // Extract HTML files from the ZIP
            string extractDir = Path.Combine(Path.GetTempPath(), "HtmlFromZip");
            Directory.CreateDirectory(extractDir);
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

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.Html to allow only local file resources
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new LocalFileOnlyHandler());

            // Render HTML to PDF
            string htmlPath = htmlFiles[0];
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string outputPdfPath = Path.Combine(Path.GetTempPath(), "output.pdf");
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                {
                    document.RenderTo(device);
                }
                Console.WriteLine($"PDF successfully created at: {outputPdfPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Message handler that permits only local file resources
public sealed class LocalFileOnlyHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}