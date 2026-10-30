// Insert ZipArchiveMessageHandler before rendering to ensure resources are resolved correctly.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = "sample.zip";
            string extractDir = Path.Combine(Path.GetTempPath(), "HTMLZipExtract");
            string outputPath = "output.pdf";

            // Ensure a sample zip exists
            if (!File.Exists(zipPath))
            {
                string tempHtmlPath = Path.Combine(Path.GetTempPath(), "sample.html");
                File.WriteAllText(tempHtmlPath, "<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("sample.html");
                    using (Stream entryStream = entry.Open())
                    using (StreamReader reader = new StreamReader(tempHtmlPath))
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
                File.Delete(tempHtmlPath);
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from the zip archive
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = new FileStream(entryPath, FileMode.Create, FileAccess.Write))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }

            // Locate the extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML files found in the extracted archive.");

            string htmlPath = htmlFiles[0];

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();

            // Insert custom message handler (optional)
            network.MessageHandlers.Insert(0, new ZipArchiveMessageHandler());

            // Load the HTML document
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Render to PDF
                using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

// Custom message handler to work with resources from the extracted zip
class ZipArchiveMessageHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Pass the request to the next handler without modification.
        Next(context);
    }
}