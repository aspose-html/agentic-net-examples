// Configure ZipFileSchemaMessageHandler before other handlers to resolve resources inside a ZIP archive.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample ZIP with an HTML file
            string zipPath = Path.Combine(Path.GetTempPath(), "sample.zip");
            string extractDir = Path.Combine(Path.GetTempPath(), "HTMLFromZip");
            Directory.CreateDirectory(extractDir);

            // Create a simple HTML file
            string sampleHtmlContent = "<html><body><h1>Hello from ZIP</h1></body></html>";
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), "temp_index.html");
            File.WriteAllText(tempHtmlPath, sampleHtmlContent);

            // Create ZIP archive containing the HTML file
            using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
            using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(tempHtmlPath, "index.html");
            }

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
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = File.Create(entryPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
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
            var configuration = new Aspose.Html.Configuration();

            // Load the HTML document
            using (var document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                // Render to PDF
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
                using (var device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPath))
                {
                    document.RenderTo(device);
                }

                Console.WriteLine("PDF generated successfully at: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}