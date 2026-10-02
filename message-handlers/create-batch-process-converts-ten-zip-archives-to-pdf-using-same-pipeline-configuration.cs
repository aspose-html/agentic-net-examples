// Create a batch process that converts ten ZIP archives to PDF using same pipeline configuration.

using System;
using System.IO;
using System.IO.Compression;

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
    public static Aspose.Html.Configuration CreateConfiguration()
    {
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
        networkService.MessageHandlers.Add(new TimeoutHandler());
        return configuration;
    }

    public static void Main(string[] args)
    {
        try
        {
            // Prepare sample ZIP files
            string baseDir = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "AsposeHtmlZipBatch");
            System.IO.Directory.CreateDirectory(baseDir);
            string[] zipPaths = new string[10];
            for (int i = 0; i < 10; i++)
            {
                string zipPath = System.IO.Path.Combine(baseDir, $"sample{i + 1}.zip");
                zipPaths[i] = zipPath;
                if (!System.IO.File.Exists(zipPath))
                {
                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        ZipArchiveEntry entry = archive.CreateEntry("index.html");
                        using (Stream entryStream = entry.Open())
                        using (StreamWriter writer = new StreamWriter(entryStream))
                        {
                            writer.Write("<!DOCTYPE html><html><body><h1>Sample " + (i + 1) + "</h1></body></html>");
                        }
                    }
                }
            }

            // Process each ZIP archive
            foreach (string zipPath in zipPaths)
            {
                string extractDirectory = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileNameWithoutExtension(zipPath));
                System.IO.Directory.CreateDirectory(extractDirectory);
                using (FileStream zipStream = System.IO.File.OpenRead(zipPath))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                            entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                        {
                            string entryPath = System.IO.Path.Combine(extractDirectory, entry.FullName);
                            string entryFolder = System.IO.Path.GetDirectoryName(entryPath);
                            if (!string.IsNullOrEmpty(entryFolder))
                                System.IO.Directory.CreateDirectory(entryFolder);
                            entry.ExtractToFile(entryPath, true);
                        }
                    }
                }

                string[] htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                {
                    htmlFiles = System.IO.Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
                    if (htmlFiles.Length == 0)
                        throw new System.IO.FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);
                }

                Aspose.Html.Configuration configuration = CreateConfiguration();
                string outputPdfPath = System.IO.Path.ChangeExtension(zipPath, ".pdf");
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine($"Converted '{zipPath}' to PDF at '{outputPdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}