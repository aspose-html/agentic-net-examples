// Configure ZipArchiveMessageHandler to handle only .html files inside the archive.

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
            // Path to the ZIP archive containing HTML files
            string zipPath = @"C:\Temp\sample.zip";

            // Temporary directory where the ZIP will be extracted
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
            Directory.CreateDirectory(extractDir);

            // Extract only .html files from the archive
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Locate the first extracted HTML file
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found in the ZIP archive.");

            string htmlPath = htmlFiles[0];

            // Create Aspose.HTML configuration (default)
            Configuration configuration = new Configuration();

            // Load the HTML document from the extracted file
            using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
            // Render the document to PDF
            using (PdfDevice device = new PdfDevice(@"C:\Temp\output.pdf"))
            {
                document.RenderTo(device);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}