// Convert HTML from a ZIP archive to PDF using ZipArchiveMessageHandler with default settings.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
            string outputPdf = Path.Combine(Path.GetTempPath(), "output.pdf");

            // Create a sample ZIP with an HTML file if it does not exist
            if (!File.Exists(zipPath))
            {
                using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("index.html");
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("<html><body><h1>Hello, Aspose.HTML!</h1></body></html>");
                    }
                }
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract HTML files from the ZIP archive
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
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
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
            {
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            }
            if (htmlFiles.Length == 0)
            {
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");
            }
            string htmlPath = htmlFiles[0];

            // Configure Aspose.HTML
            Configuration configuration = new Configuration();

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            // Create PDF device
            using (PdfDevice device = new PdfDevice(outputPdf))
            {
                // Render HTML to PDF
                document.RenderTo(device);
            }

            Console.WriteLine("PDF successfully created at: " + outputPdf);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}