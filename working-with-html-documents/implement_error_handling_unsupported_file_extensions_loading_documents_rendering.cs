// Implement error handling for unsupported file extensions when loading documents for rendering.

using System;
using System.IO;
using System.IO.Compression;

namespace AsposeHtmlExample
{
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

    class Program
    {
        static void Main()
        {
            try
            {
                // Define paths
                string zipPath = "sample.zip";
                string extractDirectory = "extracted";
                string outputPdf = "result.pdf";

                // Ensure extraction directory exists
                Directory.CreateDirectory(extractDirectory);

                // Create a sample zip with an HTML file if it does not exist
                if (!File.Exists(zipPath))
                {
                    using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                    {
                        var entry = archive.CreateEntry("index.html");
                        using (var entryStream = entry.Open())
                        using (var writer = new StreamWriter(entryStream))
                        {
                            writer.Write("<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                        }
                    }
                }

                // Extract HTML files from the zip
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

                // Locate the first HTML file
                string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                    htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                    throw new FileNotFoundException("No HTML file found after ZIP extraction.");

                // Configure Aspose.HTML to allow only local file resources
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Insert(0, new LocalFileOnlyHandler());

                // Load the HTML document with the custom configuration
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                // Render to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdf))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"PDF successfully created at '{Path.GetFullPath(outputPdf)}'.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}