// Combine ZipFileSchemaMessageHandler with NetworkDisabledMessageHandler to safely load HTML from ZIP while restricting protocols.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html.Net;
using Aspose.Html.Services;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html;

public sealed class ZipFileSchemaMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        string requestUri = context.Request.RequestUri == null ? string.Empty : context.Request.RequestUri.ToString();
        if (!string.IsNullOrEmpty(requestUri) && !requestUri.StartsWith("file:", System.StringComparison.OrdinalIgnoreCase))
            throw new System.InvalidOperationException("Only file protocol is allowed.");
        Next(context);
    }
}

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
    public static void Main()
    {
        try
        {
            // Prepare sample ZIP with an HTML file
            string tempDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlSample");
            System.IO.Directory.CreateDirectory(tempDir);
            string htmlFilePath = System.IO.Path.Combine(tempDir, "sample.html");
            System.IO.File.WriteAllText(htmlFilePath, "<!DOCTYPE html><html><body><h1>Hello from ZIP</h1></body></html>");

            string zipPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.zip");
            if (System.IO.File.Exists(zipPath))
                System.IO.File.Delete(zipPath);
            System.IO.Compression.ZipFile.CreateFromDirectory(tempDir, zipPath);

            // Extraction directory
            string extractDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlExtracted");
            System.IO.Directory.CreateDirectory(extractDirectory);

            // Extract HTML files from ZIP
            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(zipPath))
            using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Read))
            {
                foreach (System.IO.Compression.ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", System.StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", System.StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = System.IO.Path.Combine(extractDirectory, entry.FullName);
                        string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                        if (!string.IsNullOrEmpty(entryFolder))
                            System.IO.Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate extracted HTML file
            string[] htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.htm", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML with custom message handlers
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Insert(0, new ZipFileSchemaMessageHandler());
            networkService.MessageHandlers.Insert(1, new NetworkDisabledMessageHandler());

            // Render HTML to PDF
            string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "output.pdf");
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}