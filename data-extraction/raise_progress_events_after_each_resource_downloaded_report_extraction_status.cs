// Raise progress events after each resource is downloaded to report extraction status.

using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;

public sealed class ProgressMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Stopwatch timer = Stopwatch.StartNew();
        Next(context);
        timer.Stop();
        Console.WriteLine("Resource downloaded: " + context.Request.RequestUri + " in " + timer.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string extractDirectory = "extracted";
            string outputPdfPath = "output.pdf";

            // Create a sample ZIP with an HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("index.html");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write("<html><body><h1>Hello World</h1></body></html>");
                    }
                }
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract HTML files from the ZIP
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
                        {
                            Directory.CreateDirectory(entryFolder);
                        }
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");
            }

            // Configure Aspose.HTML with the progress message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new ProgressMessageHandler());

            // Convert HTML to PDF
            Stopwatch conversionTimer = Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
            conversionTimer.Stop();

            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}