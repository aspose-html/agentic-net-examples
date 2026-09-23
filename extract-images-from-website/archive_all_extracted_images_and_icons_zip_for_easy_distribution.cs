// Archive all extracted images and icons into a ZIP file for easy distribution.

using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        try
        {
            // Input ZIP containing HTML, images, icons
            string zipPath = "sample.zip";
            // Directory to extract files
            string extractDir = Path.Combine(Path.GetTempPath(), "ExtractedContent");
            Directory.CreateDirectory(extractDir);

            // Extract images, icons, and HTML files
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".ico", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".html", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".htm", StringComparison.OrdinalIgnoreCase))
                    {
                        string entryPath = Path.Combine(extractDir, entry.FullName);
                        Directory.CreateDirectory(Path.GetDirectoryName(entryPath));
                        entry.ExtractToFile(entryPath, true);
                    }
                }
            }

            // If an HTML file was extracted, render it to PDF using Aspose.HTML
            string[] htmlFiles = Directory.GetFiles(extractDir, "*.html", SearchOption.AllDirectories);
            if (htmlFiles.Length == 0)
                htmlFiles = Directory.GetFiles(extractDir, "*.htm", SearchOption.AllDirectories);

            if (htmlFiles.Length > 0)
            {
                string htmlPath = htmlFiles[0];
                Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
                {
                    string pdfPath = Path.Combine(extractDir, "output.pdf");
                    using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
                    {
                        document.RenderTo(device);
                    }
                }
            }

            // Create a ZIP archive containing all extracted images, icons, and the generated PDF
            string outputZipPath = "images_archive.zip";
            using (FileStream zipToCreate = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive outArchive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
            {
                foreach (string file in Directory.GetFiles(extractDir, "*.*", SearchOption.AllDirectories))
                {
                    string entryName = Path.GetRelativePath(extractDir, file);
                    outArchive.CreateEntryFromFile(file, entryName);
                }
            }

            Console.WriteLine("Images, icons, and PDF have been archived to: " + outputZipPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine("An error occurred: " + ex.Message);
        }
    }
}