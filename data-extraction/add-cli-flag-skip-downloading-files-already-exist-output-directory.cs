// Add a CLI flag to skip downloading files that already exist in the output directory.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
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
        try
        {
            // Default values
            string inputZip = Path.Combine(Environment.CurrentDirectory, "sample.zip");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "output");
            bool skipExisting = false;

            // Parse CLI arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("--input", System.StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    inputZip = args[i + 1];
                    i++;
                }
                else if (args[i].Equals("--output", System.StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    outputDir = args[i + 1];
                    i++;
                }
                else if (args[i].Equals("--skip-existing", System.StringComparison.OrdinalIgnoreCase))
                {
                    skipExisting = true;
                }
            }

            // Ensure output directory exists
            System.IO.Directory.CreateDirectory(outputDir);

            // Create a minimal sample zip if it does not exist
            if (!System.IO.File.Exists(inputZip))
            {
                string tempHtml = Path.Combine(Path.GetTempPath(), "sample.html");
                System.IO.File.WriteAllText(tempHtml, "<!DOCTYPE html><html><body><h1>Sample</h1></body></html>");
                using (System.IO.FileStream zipStream = System.IO.File.Create(inputZip))
                using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipStream, System.IO.Compression.ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(tempHtml, "sample.html");
                }
                System.IO.File.Delete(tempHtml);
            }

            // Extract zip to a temporary directory
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract_" + System.Guid.NewGuid().ToString("N"));
            System.IO.Directory.CreateDirectory(extractDir);
            using (System.IO.FileStream zipStream = System.IO.File.OpenRead(inputZip))
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
                        {
                            System.IO.Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Find HTML files
            string[] htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.html", System.IO.SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = System.IO.Directory.GetFiles(extractDir, "*.htm", System.IO.SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new System.IO.FileNotFoundException("No HTML files found after extraction.");
            }

            // Process each HTML file
            foreach (string htmlPath in htmlFiles)
            {
                string outputPath = System.IO.Path.Combine(outputDir, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".pdf");

                if (skipExisting && System.IO.File.Exists(outputPath))
                {
                    System.Console.WriteLine("Skipping existing file: " + outputPath);
                    continue;
                }

                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
                networkService.MessageHandlers.Insert(0, new TimeoutHandler());

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                System.Console.WriteLine("Converted: " + htmlPath + " -> " + outputPath);
            }

            // Cleanup extracted files
            System.IO.Directory.Delete(extractDir, true);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error: " + ex.Message);
        }
    }
}