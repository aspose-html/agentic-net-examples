// Add a CLI flag to skip downloading files that already exist in the output directory.

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

public class Program
{
    public static void Main(string[] args)
    {
        bool skipExisting = false;
        foreach (string arg in args)
        {
            if (arg.Equals("--skip-existing", StringComparison.OrdinalIgnoreCase))
            {
                skipExisting = true;
                break;
            }
        }

        try
        {
            // Define paths (adjust as needed)
            string zipPath = "sample.zip";
            string extractDirectory = Path.Combine(Path.GetTempPath(), "HtmlExtract");
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");

            // Ensure output directory exists
            System.IO.Directory.CreateDirectory(outputDirectory);
            System.IO.Directory.CreateDirectory(extractDirectory);

            // If the sample zip does not exist, create a minimal one with a simple HTML file
            if (!System.IO.File.Exists(zipPath))
            {
                using (System.IO.FileStream zipStream = new System.IO.FileStream(zipPath, System.IO.FileMode.Create))
                using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
                {
                    var entry = archive.CreateEntry("sample.html");
                    using (var entryStream = entry.Open())
                    using (var writer = new System.IO.StreamWriter(entryStream))
                    {
                        writer.Write("<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                    }
                }
            }

            // Extract HTML files from the zip
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
                        {
                            System.IO.Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Get list of HTML files
            string[] htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.htm", System.IO.SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.");
            }

            // Process each HTML file
            foreach (string htmlFile in htmlFiles)
            {
                string outputPath = System.IO.Path.Combine(outputDirectory, System.IO.Path.GetFileNameWithoutExtension(htmlFile) + ".pdf");

                if (skipExisting && System.IO.File.Exists(outputPath))
                {
                    System.Console.WriteLine($"Skipping existing file: {outputPath}");
                    continue;
                }

                // Configure network service with timeout handler
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Insert(0, new TimeoutHandler());

                // Load HTML document and render to PDF
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFile, configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine($"Converted '{htmlFile}' to PDF at '{outputPath}'.");
            }
        }
        catch (Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}