// Create a script that processes a list of ZIP files, extracts HTML, and converts each to PDF.

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
            string[] zipPaths = new string[]
            {
                @"C:\Input\sample1.zip",
                @"C:\Input\sample2.zip"
            };

            foreach (string zipPath in zipPaths)
            {
                ProcessZip(zipPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ProcessZip(string zipPath)
    {
        // Create a temporary extraction directory
        string extractDir = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(zipPath));
        Directory.CreateDirectory(extractDir);

        // Extract HTML entries from the zip archive
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

        // Locate the extracted HTML file
        string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
        if (htmlFiles.Length == 0)
        {
            htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                throw new FileNotFoundException("No HTML file found after ZIP extraction.", zipPath);
        }
        string htmlPath = htmlFiles[0];

        // Load the HTML document with Aspose.HTML configuration
        Configuration configuration = new Configuration();
        using (HTMLDocument document = new HTMLDocument(htmlPath, configuration))
        {
            // Define output PDF path
            string outputPdfPath = Path.ChangeExtension(zipPath, ".pdf");

            // Render to PDF
            using (PdfDevice device = new PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
        }

        // Clean up extracted files
        Directory.Delete(extractDir, true);
    }
}