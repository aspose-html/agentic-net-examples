// Create a batch process that converts ten ZIP archives to PDF using same pipeline configuration.

using System;
using System.IO;
using System.IO.Compression;

public sealed class TimeoutHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        context.Request.Timeout = TimeSpan.FromSeconds(30);
        Next(context);
    }
}

public static class ConfigurationFactory
{
    public static Aspose.Html.Configuration CreateConfiguration()
    {
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
        networkService.MessageHandlers.Add(new TimeoutHandler());
        return configuration;
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string baseFolder = Path.Combine(Path.GetTempPath(), "AsposeHtmlZipBatch");
            Directory.CreateDirectory(baseFolder);

            // Create sample ZIP archives with a simple HTML file
            for (int i = 1; i <= 10; i++)
            {
                string zipPath = Path.Combine(baseFolder, $"sample{i}.zip");
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("index.html");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write($"<html><body><h1>Sample {i}</h1></body></html>");
                    }
                }
            }

            string[] zipPaths = new string[]
            {
                Path.Combine(baseFolder, "sample1.zip"),
                Path.Combine(baseFolder, "sample2.zip"),
                Path.Combine(baseFolder, "sample3.zip"),
                Path.Combine(baseFolder, "sample4.zip"),
                Path.Combine(baseFolder, "sample5.zip"),
                Path.Combine(baseFolder, "sample6.zip"),
                Path.Combine(baseFolder, "sample7.zip"),
                Path.Combine(baseFolder, "sample8.zip"),
                Path.Combine(baseFolder, "sample9.zip"),
                Path.Combine(baseFolder, "sample10.zip")
            };

            foreach (string zipPath in zipPaths)
            {
                string extractDirectory = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipPath));
                Directory.CreateDirectory(extractDirectory);

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

                string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                {
                    htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
                    if (htmlFiles.Length == 0)
                        throw new FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);
                }

                Aspose.Html.Configuration configuration = ConfigurationFactory.CreateConfiguration();
                string outputPdfPath = Path.ChangeExtension(zipPath, ".pdf");

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}