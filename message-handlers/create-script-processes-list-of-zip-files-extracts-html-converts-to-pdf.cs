// Create a script that processes a list of ZIP files, extracts HTML, and converts each to PDF.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample ZIP files (for demonstration purposes)
            string baseTempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlSample");
            Directory.CreateDirectory(baseTempDir);

            string[] zipPaths = new string[2];
            for (int i = 0; i < zipPaths.Length; i++)
            {
                string htmlFileName = $"sample{i}.html";
                string zipFileName = $"sample{i}.zip";
                string htmlFilePath = Path.Combine(baseTempDir, htmlFileName);
                string zipFilePath = Path.Combine(baseTempDir, zipFileName);

                // Create simple HTML file
                string htmlContent = $"<html><body><h1>Sample {i}</h1><p>This is a test.</p></body></html>";
                File.WriteAllText(htmlFilePath, htmlContent);

                // Create ZIP containing the HTML file
                using (FileStream zipStream = new FileStream(zipFilePath, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry entry = archive.CreateEntry(htmlFileName);
                    using (Stream entryStream = entry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write(htmlContent);
                    }
                }

                zipPaths[i] = zipFilePath;
            }

            // Process each ZIP: extract HTML and convert to PDF
            foreach (string zipPath in zipPaths)
            {
                string extractDirectory = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipPath));
                Directory.CreateDirectory(extractDirectory);

                // Extract HTML files from ZIP
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

                // Locate extracted HTML file
                string[] htmlFiles = Directory.GetFiles(extractDirectory, "*.html", SearchOption.AllDirectories);
                if (htmlFiles.Length == 0)
                {
                    htmlFiles = Directory.GetFiles(extractDirectory, "*.htm", SearchOption.AllDirectories);
                    if (htmlFiles.Length == 0)
                        throw new FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);
                }

                // Convert HTML to PDF
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
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