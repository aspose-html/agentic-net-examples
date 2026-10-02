// Configure ZipArchiveMessageHandler to handle only .html files inside the archive.

using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            string zipPath = "sample.zip";
            string outputPdf = "output.pdf";

            // Create a sample ZIP archive with an HTML file if it doesn't exist
            if (!File.Exists(zipPath))
            {
                using (FileStream zipStream = File.Create(zipPath))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry("test.html");
                    using (StreamWriter writer = new StreamWriter(entry.Open()))
                    {
                        writer.Write("<html><body><h1>Hello from ZIP</h1></body></html>");
                    }
                }
            }

            // Extract HTML files from the ZIP archive to a temporary directory
            string extractDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlExtract");
            Directory.CreateDirectory(extractDir);

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
                            Directory.CreateDirectory(entryFolder);
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the extracted HTML file
            string htmlPath = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories).FirstOrDefault()
                ?? Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories).FirstOrDefault();

            if (htmlPath == null)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.");

            // Configure Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            // Load the HTML document and render to PDF
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdf))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("PDF generated successfully at: " + Path.GetFullPath(outputPdf));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}