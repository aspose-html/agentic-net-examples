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
            string[] zipPaths = new string[]
            {
                "sample1.zip",
                "sample2.zip",
                "sample3.zip",
                "sample4.zip",
                "sample5.zip",
                "sample6.zip",
                "sample7.zip",
                "sample8.zip",
                "sample9.zip",
                "sample10.zip"
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

                Console.WriteLine($"Converted '{zipPath}' to PDF at '{outputPdfPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}