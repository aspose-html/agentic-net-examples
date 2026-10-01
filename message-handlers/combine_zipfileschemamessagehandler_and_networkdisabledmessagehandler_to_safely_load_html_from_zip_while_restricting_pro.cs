// Combine ZipFileSchemaMessageHandler with NetworkDisabledMessageHandler to safely load HTML from ZIP while restricting protocols.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Net;

public sealed class NetworkDisabledMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Only local file resources are allowed.");
        Next(context);
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDirectory = Path.Combine(Path.GetTempPath(), "HtmlFromZip");
            string outputPath = "result.pdf";

            // Create a sample ZIP file with an HTML document if it does not exist
            if (!File.Exists(zipPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>";
                using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("sample.html");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write(sampleHtml);
                    }
                }
            }

            Directory.CreateDirectory(extractDirectory);

            // Extract HTML files from the ZIP archive
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

                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = new FileStream(entryPath, FileMode.Create, FileAccess.Write))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML with network restrictions
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new NetworkDisabledMessageHandler());

            // Load the HTML document and render it to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}