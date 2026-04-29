// Create a batch process that converts ten ZIP archives to PDF using same pipeline configuration.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Net;
using Aspose.Html.Services;

class Program
{
    static void Main()
    {
        try
        {
            BatchConvertZipsToPdf();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void BatchConvertZipsToPdf()
    {
        string[] zipPaths = new string[]
        {
            "C:\\Zips\\file1.zip",
            "C:\\Zips\\file2.zip",
            "C:\\Zips\\file3.zip",
            "C:\\Zips\\file4.zip",
            "C:\\Zips\\file5.zip",
            "C:\\Zips\\file6.zip",
            "C:\\Zips\\file7.zip",
            "C:\\Zips\\file8.zip",
            "C:\\Zips\\file9.zip",
            "C:\\Zips\\file10.zip"
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

            Aspose.Html.Configuration configuration = CreateConfiguration();
            string outputPdfPath = Path.ChangeExtension(zipPath, ".pdf");
            using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
            using (PdfDevice device = new PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
        }
    }

    public static Aspose.Html.Configuration CreateConfiguration()
    {
        Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
        INetworkService networkService = configuration.GetService<INetworkService>();
        networkService.MessageHandlers.Add(new TimeoutHandler());
        return configuration;
    }

    public sealed class TimeoutHandler : MessageHandler
    {
        public override void Invoke(INetworkOperationContext context)
        {
            context.Request.Timeout = TimeSpan.FromSeconds(30);
            Next(context);
        }
    }
}