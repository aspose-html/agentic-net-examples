// Archive all extracted images and icons into a ZIP file for easy distribution.

using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string sourceZipPath = Path.Combine(Path.GetTempPath(), "source.zip");
            string extractDir = Path.Combine(Path.GetTempPath(), "extracted_assets");
            string outputZipPath = Path.Combine(Path.GetTempPath(), "ImagesAndIcons.zip");

            // Ensure clean directories
            if (Directory.Exists(extractDir))
                Directory.Delete(extractDir, true);
            Directory.CreateDirectory(extractDir);

            // Create a sample source zip with dummy image/icon files if it does not exist
            if (!File.Exists(sourceZipPath))
            {
                using (FileStream srcStream = new FileStream(sourceZipPath, FileMode.Create))
                using (ZipArchive srcArchive = new ZipArchive(srcStream, ZipArchiveMode.Create))
                {
                    // Dummy PNG
                    ZipArchiveEntry pngEntry = srcArchive.CreateEntry("images/sample.png");
                    using (Stream entryStream = pngEntry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("dummy png content");
                    }

                    // Dummy JPG
                    ZipArchiveEntry jpgEntry = srcArchive.CreateEntry("icons/icon.jpg");
                    using (Stream entryStream = jpgEntry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("dummy jpg content");
                    }

                    // Non-image file (should be ignored)
                    ZipArchiveEntry txtEntry = srcArchive.CreateEntry("docs/readme.txt");
                    using (Stream entryStream = txtEntry.Open())
                    using (StreamWriter writer = new StreamWriter(entryStream))
                    {
                        writer.Write("just a text file");
                    }
                }
            }

            // Extract only image and icon files from the source zip
            using (FileStream zipStream = File.OpenRead(sourceZipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // Optional: Load an HTML file from the extracted assets and render to PDF using Aspose.HTML
            // (Demonstrates usage of Aspose.HTML without affecting the zip operation)
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length > 0)
            {
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFiles[0], configuration))
                {
                    string pdfPath = Path.ChangeExtension(htmlFiles[0], ".pdf");
                    using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            // Create a new zip containing only the extracted images and icons
            if (File.Exists(outputZipPath))
                File.Delete(outputZipPath);
            using (FileStream outStream = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive outArchive = new ZipArchive(outStream, ZipArchiveMode.Create))
            {
                foreach (string filePath in Directory.GetFiles(extractDir, "*.*", SearchOption.AllDirectories))
                {
                    if (filePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        filePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        filePath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        filePath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                        filePath.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) ||
                        filePath.EndsWith(".svg", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryName = Path.GetRelativePath(extractDir, filePath);
                        outArchive.CreateEntryFromFile(filePath, entryName);
                    }
                }
            }

            Console.WriteLine("Extraction and archiving completed successfully.");
            Console.WriteLine($"Extracted assets directory: {extractDir}");
            Console.WriteLine($"Output ZIP file: {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}