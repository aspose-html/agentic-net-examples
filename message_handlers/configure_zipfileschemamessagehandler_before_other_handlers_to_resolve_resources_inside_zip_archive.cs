// Configure ZipFileSchemaMessageHandler before other handlers to resolve resources inside a ZIP archive.

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Html;
using Aspose.Html.Rendering.Pdf;

namespace ZipHtmlToPdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string zipPath = "input.zip";
                string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedHtml");
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
                            Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                            entry.ExtractToFile(entryPath, true);
                        }
                    }
                }

                string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                {
                    htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
                }
                if (htmlFiles.Length == 0)
                    throw new FileNotFoundException("No HTML file found after ZIP extraction.");

                Configuration configuration = new Configuration();

                using (HTMLDocument document = new HTMLDocument(htmlFiles[0], configuration))
                using (PdfDevice device = new PdfDevice("output.pdf"))
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
}